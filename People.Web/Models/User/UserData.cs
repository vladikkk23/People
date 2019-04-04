using People.Domain.Enums;

namespace People.Web.Models.User
{
    public class UserData
    {
        public string Username { get; set; }
        public string ProfileImageUrl { get; set; }
        public Role Level { get; set; }
    }
}
