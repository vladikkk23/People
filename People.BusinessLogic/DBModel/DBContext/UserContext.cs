using System.Data.Entity;
using People.Domain.Entities.User.UserDataTables;

namespace People.BusinessLogic.DBModel.DBContext
{
    public class UserContext: DbContext
    {
        public UserContext() : base("name=People") // connectionstring name define in your web.config
        {
        }

        public virtual DbSet<UDataTable> Users { get; set; }
    }
}
