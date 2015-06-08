using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using APIManagmentConsole.Models;
using APIManagmentConsole.Models.Enum;
using APIManagmentConsole.Services;
using APIManagmentConsole.ViewModel.Extensions;
using GalaSoft.MvvmLight.Command;

namespace APIManagmentConsole.ViewModel
{
    public class UserListViewModel : BaseViewModel
    {
        private readonly IUserService userService;
        private readonly MainViewModel parent;

        private bool showUserList;
       
        private bool showUserDetail;
        private User selectedUser;
        private RelayCommand getUserDetailCommand;
        private RelayCommand deleteUserCommand;
        private RelayCommand blockUserCommand;
        private RelayCommand activateUserCommand;
        private RelayCommand cancelCommand;


        public ObservableCollection<User> Users { get; set; }

        public UserListViewModel(IUserService userService, MainViewModel parent)
        {
            this.userService = userService;
            this.parent = parent;

            Users = new ObservableCollection<User>();
        }

        public RelayCommand GetUserDetailCommand
        {
            get
            {
                return getUserDetailCommand ??
                       (getUserDetailCommand = new RelayCommand(async () => await DoGetUserDetail(), CanActionUser));
            }
        }
        public RelayCommand DeleteUserCommand
        {
            get
            {
                return deleteUserCommand ??
                       (deleteUserCommand = new RelayCommand(
                           async () =>
                           {
                               var messageBoxResult = MessageBox.Show(string.Format("Are you sure you want to delete user : {0}?",SelectedUser.FirstName + " " + SelectedUser.LastName), "Delete Confirmation", MessageBoxButton.YesNo);
                               if (messageBoxResult == MessageBoxResult.Yes)
                               {
                                   await DoDeleteUser();
                               }
                           }, 
                           CanActionUser));
            }
        }
        public RelayCommand ActivateUserCommand
        {
            get
            {
                return activateUserCommand ??
                       (activateUserCommand = new RelayCommand(async () => await DoActivateUser(), CanActionUser));
            }
        }
        public RelayCommand BlockUserCommand
        {
            get
            {
                return blockUserCommand ??
                       (blockUserCommand = new RelayCommand(async () => await DoBlockUser(), CanActionUser));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new RelayCommand(() =>
                {
                    SelectedUser = null;
                    ShowUserDetail = false;
                    ShowUserList = true;

                }));
            }
        }

        public bool ShowUserDetail
        {
            get { return showUserDetail; }
            set
            {
                showUserDetail = value;
                RaisePropertyChanged("ShowUserDetail");
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                GetUserDetailCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged("SelectedUser");
                ShowUserDetail = false;
            }
        }

        public bool ShowUserList
        {
            get { return showUserList;}
            set
            {
                showUserList = value;
                RaisePropertyChanged("ShowUserList");
            }
        }

        public override async Task DoLoad ()
        {
            var list = await userService.ListAysnc(
                App.GetApplicationContext().GetSubscriptionId(),
                App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                App.GetApplicationContext().GetResourceGroup(), App.GetApplicationContext().GetServiceName());

            Users.ClearAndAddAll(list);
            ShowUserList = true;
        }

        private async Task DoGetUserDetail()
        {
            var user = await userService.GetAsync(App.GetApplicationContext().GetSubscriptionId(),
                App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                App.GetApplicationContext().GetResourceGroup(), App.GetApplicationContext().GetServiceName(),
                SelectedUser.Id);

            if (user != null) {
                SelectedUser = user;
                SelectedUser.AssociatedGroups = new List<Group>(await DoGetUserGroups(user.Id));
                RaisePropertyChanged("SelectedUser");
                ActivateUserCommand.RaiseCanExecuteChanged();
                BlockUserCommand.RaiseCanExecuteChanged();
                ShowUserDetail = true;
                ShowUserList = false;
            }
        }


        private async Task<List<Group>>  DoGetUserGroups(string userId)
        {
            var list = await userService.ListUserGroupsAsync(App.GetApplicationContext().GetSubscriptionId(),
                App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                App.GetApplicationContext().GetResourceGroup(), App.GetApplicationContext().GetServiceName(),
                userId);

            return list;


        }

        private async Task DoActivateUser()
        {
            selectedUser.State = UserState.Active;
            var success = await userService.UpdateAsync(App.GetApplicationContext().GetSubscriptionId(),
                App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                App.GetApplicationContext().GetResourceGroup(), App.GetApplicationContext().GetServiceName(),
                selectedUser);

            if (success)
            {
                App.ShowMessage(string.Format("User {0} has been activated.",
                    SelectedUser.FirstName + " " + SelectedUser.LastName));
                SelectedUser = null;
                ShowUserDetail = false;
                await DoLoad();

            }
            else
            {
                App.ShowMessage("User activation failed.");
            }
        }

        private async Task DoBlockUser()
        {
            selectedUser.State = UserState.Blocked;
            var success = await userService.UpdateAsync(App.GetApplicationContext().GetSubscriptionId(),
                App.GetApplicationContext().GetSecurityContext().GetAccessToken(),
                App.GetApplicationContext().GetResourceGroup(), App.GetApplicationContext().GetServiceName(),
                selectedUser);

            if (success)
            {
                App.ShowMessage(string.Format("User {0} has been blocked.",
                    SelectedUser.FirstName + " " + SelectedUser.LastName));
                SelectedUser = null;
                ShowUserDetail = false;
                await DoLoad();

            }
            else
            {
                App.ShowMessage(string.Format("Blocking of User {0} failed.", SelectedUser.FirstName + " " + SelectedUser.LastName));
            }
        }

        private bool CanActionUser()
        {
            return SelectedUser != null;
        }

        private async Task DoDeleteUser()
        {
            Users.Remove(SelectedUser);
        }

    }
}
