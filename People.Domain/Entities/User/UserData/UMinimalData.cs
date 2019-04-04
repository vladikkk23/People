using System;
using People.Domain.Enums;

namespace People.Domain.Entities.User.UserData
{
    public class UMinimalData
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime LastLogin { get; set; }
        public string LastIp { get; set; }
        public Role Level { get; set; }
    }
}
