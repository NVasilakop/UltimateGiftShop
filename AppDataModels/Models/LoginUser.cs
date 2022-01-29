namespace AppDataModels.Models
{
    public class LoginUser: User
    {
        public bool? LoggedIn { get; set; }
        public string Password { get; set; }
    }
}