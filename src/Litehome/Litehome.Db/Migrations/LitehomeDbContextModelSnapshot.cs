﻿// <auto-generated />
using System;
using Litehome.Db.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Litehome.Db.Migrations
{
    [DbContext(typeof(LitehomeDbContext))]
    partial class LitehomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Litehome.Db.Models.Expense", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpenseCategoryId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Frequency")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HomeMemberId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsSavings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseCategoryId");

                    b.HasIndex("HomeMemberId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Litehome.Db.Models.ExpenseCategory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategories");

                    b.HasData(
                        new
                        {
                            Id = "fb7cafed-001d-44ad-8fa7-83bb3cbea7bd",
                            Name = "General"
                        });
                });

            modelBuilder.Entity("Litehome.Db.Models.HomeMember", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HomeMembers");
                });

            modelBuilder.Entity("Litehome.Db.Models.Income", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnOrder(0);

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("Frequency")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HomeMemberId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HomeMemberId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("Litehome.Db.Models.Expense", b =>
                {
                    b.HasOne("Litehome.Db.Models.ExpenseCategory", "ExpenseCategory")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseCategoryId");

                    b.HasOne("Litehome.Db.Models.HomeMember", "HomeMember")
                        .WithMany("Expenses")
                        .HasForeignKey("HomeMemberId");

                    b.Navigation("ExpenseCategory");

                    b.Navigation("HomeMember");
                });

            modelBuilder.Entity("Litehome.Db.Models.Income", b =>
                {
                    b.HasOne("Litehome.Db.Models.HomeMember", "HomeMember")
                        .WithMany("Incomes")
                        .HasForeignKey("HomeMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomeMember");
                });

            modelBuilder.Entity("Litehome.Db.Models.ExpenseCategory", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Litehome.Db.Models.HomeMember", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });
#pragma warning restore 612, 618
        }
    }
}
