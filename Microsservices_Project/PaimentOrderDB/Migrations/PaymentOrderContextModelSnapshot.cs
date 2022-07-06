﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentOrderDB.Data.Context;

#nullable disable

namespace PaymentOrderDB.Migrations
{
    [DbContext(typeof(PaymentOrderContext))]
    partial class PaymentOrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Entities.PaymentOrderData", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("discount")
                        .HasColumnType("double");

                    b.Property<double>("shippingCost")
                        .HasColumnType("double");

                    b.Property<double>("total")
                        .HasColumnType("double");

                    b.Property<double>("totalToPay")
                        .HasColumnType("double");

                    b.Property<long>("userId")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("PaymentOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
