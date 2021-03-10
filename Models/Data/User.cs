namespace Bibliotheek.Models.Data
{
    public class User : DataModelBase
    {
        public static string CollectionName => "users";
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User() { }
        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
