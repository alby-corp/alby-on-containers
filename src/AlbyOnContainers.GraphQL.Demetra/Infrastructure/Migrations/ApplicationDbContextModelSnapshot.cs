﻿// <auto-generated />
using System;
using Demetra.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demetra.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Demetra.Model.Attr", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Attrs");
                });

            modelBuilder.Entity("Demetra.Model.AttrDescr", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AttrId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AttrId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("AttrDescrs");
                });

            modelBuilder.Entity("Demetra.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Demetra.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Demetra.Model.AttrDescr", b =>
                {
                    b.HasOne("Demetra.Model.Attr", "Attr")
                        .WithMany("Descrs")
                        .HasForeignKey("AttrId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Demetra.Model.Product", "Product")
                        .WithMany("Descrs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Attr");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Demetra.Model.Category", b =>
                {
                    b.HasOne("Demetra.Model.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Demetra.Model.Product", b =>
                {
                    b.HasOne("Demetra.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Demetra.Model.Attr", b =>
                {
                    b.Navigation("Descrs");
                });

            modelBuilder.Entity("Demetra.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Demetra.Model.Product", b =>
                {
                    b.Navigation("Descrs");
                });
#pragma warning restore 612, 618
        }
    }
}
