using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace PaymentOrderDB.Data.Context
{
    public class PaymentOrderContext : DbContext
    {
        public PaymentOrderContext(DbContextOptions<PaymentOrderContext> dbContextOptions) : base(dbContextOptions)
        {
                    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<PaymentOrderData>().Property(x => x.id)
                .UseIdentityColumn()
                .IsRequired();

            modelBuilder.Entity<PaymentOrderData>().Property(x => x.shippingCost)
                .IsRequired();

            modelBuilder.Entity<PaymentOrderData>().Property(x => x.total)
                .IsRequired();

            modelBuilder.Entity<PaymentOrderData>().Property(x => x.totalToPay)
                .IsRequired();

            modelBuilder.Entity<PaymentOrderData>().Property(x => x.discount)
                .IsRequired();

            modelBuilder.Entity<PaymentOrderData>().Property(x => x.userId)
                .IsRequired();

        }

        public DbSet<PaymentOrderData> PaymentOrders { get; set; }
    }
}
