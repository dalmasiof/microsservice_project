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
            modelBuilder.Entity<UserData>().Property(x => x.id)
                .IsRequired()
                .UseIdentityColumn();

            modelBuilder.Entity<UserData>().Property(x => x.email)
                .IsRequired()
                .HasMaxLength(256);

            modelBuilder.Entity<UserData>().Property(x => x.birthDate)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<UserData>().Property(x => x.name)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<UserData>().Property(x => x.lastName)
                .IsRequired()
                .HasMaxLength(500);


        }
        public DbSet<UserData> UserDatas { get; set; }
    }
}
