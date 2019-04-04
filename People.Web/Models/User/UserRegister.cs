namespace People.Web.Models.User
{
    public class UserRegister
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
