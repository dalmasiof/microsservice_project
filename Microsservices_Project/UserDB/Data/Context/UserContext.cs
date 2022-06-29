using Microsoft.EntityFrameworkCore;

namespace UserDB.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> dbContextOptions) : base(dbContextOptions)
        {


        }
        public DbSet<UserData> Users { get; set; }
    }
}
