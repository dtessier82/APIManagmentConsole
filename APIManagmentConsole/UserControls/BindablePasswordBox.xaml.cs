using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace APIManagmentConsole.UserControls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        public static readonly DependencyProperty SecurePasswordProperty = DependencyProperty.Register(
          "SecurePassword", typeof(SecureString), typeof(BindablePasswordBox), new PropertyMetadata(default(SecureString)));

        public SecureString SecurePassword
        {
            get { return (SecureString)GetValue(SecurePasswordProperty); }
            set { SetValue(SecurePasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            SecurePassword = ((PasswordBox)sender).SecurePassword;
        }

        private void BindablePasswordBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            passwordBox.Focus();
        }
    }
}
