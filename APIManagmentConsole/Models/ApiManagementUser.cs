namespace APIManagmentConsole.Models
{
    public class ApiManagementUser
    {
        public ApiManagementUser(User user)
        {
            Id = "/users/" + user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Note = user.Note;
            State = user.State.ToString().ToLower();
        }

        public string Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Note { get; private set; }
        public string State { get; private set; }
    }
}
