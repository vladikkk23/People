using System;
using System.Data.Entity;
using People.Domain.Entities.User.UserDataTables;

namespace People.BusinessLogic.DBModel.DBContext
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=People")
        {
        }

        public virtual DbSet<SessionDBTable> Sessions { get; set; }
    }
}
