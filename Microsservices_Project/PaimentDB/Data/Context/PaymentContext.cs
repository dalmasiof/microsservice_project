using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaymentDB.Data.Context
{
    public class PaymentCOntext : DbContext
    {
        public PaymentCOntext(DbContextOptions<PaymentCOntext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentData>().Property(x => x.id)
                .UseIdentityColumn()
                .IsRequired();

            modelBuilder.Entity<PaymentData>().Property(x => x.idUser)
                .IsRequired();

            modelBuilder.Entity<PaymentData>().Property(x => x.idPaymentOrder)
                .IsRequired();

            modelBuilder.Entity<PaymentData>().Property(x => x.paymentDate)
                .IsRequired();

            modelBuilder.Entity<PaymentData>().Property(x => x.value)
                .IsRequired();
        }

        public DbSet<PaymentData> paymentDatas { get; set; }
    }
}
