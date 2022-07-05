using Microsoft.EntityFrameworkCore;

namespace UserDB.Data.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> dbContextOptions) : base(dbContextOptions)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().Property(x => x.Id)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder.Entity<UserData>().Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<UserData>().Property(x => x.BirthDate)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<UserData>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<UserData>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(500);


        }
        public DbSet<UserData> UserDatas { get; set; }
    }
}
