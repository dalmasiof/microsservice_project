﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentDB.Data.Context;

#nullable disable

namespace PaymentDB.Migrations
{
    [DbContext(typeof(PaymentCOntext))]
    [Migration("20220711163208_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Entities.PaymentData", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1L)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("idPaymentOrder")
                        .HasColumnType("bigint");

                    b.Property<long>("idUser")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("paymentDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("value")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("paymentDatas");
                });
#pragma warning restore 612, 618
        }
    }
}
