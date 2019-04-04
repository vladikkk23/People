using System;

namespace People.Domain.Entities.User.UserData
{
    public class ULoginData
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDateTime { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
