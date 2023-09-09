﻿// <auto-generated />
using BookStoreApp.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreApp.DataAccess.Migrations
{
    [DbContext(typeof(BookStoreAppDbContext))]
    [Migration("20230906142414_AddSeedCustomerUserAndBookToDb")]
    partial class AddSeedCustomerUserAndBookToDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreApp.Domain.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Berkeley",
                            FirstName = "Abraham",
                            LastName = "Bennet",
                            State = "CA"
                        },
                        new
                        {
                            Id = 2,
                            City = "Menlo Park",
                            FirstName = "Johnson",
                            LastName = "White",
                            State = "CA"
                        },
                        new
                        {
                            Id = 3,
                            City = "San Francisco",
                            FirstName = "Charlene",
                            LastName = "Locksley",
                            State = "CA"
                        },
                        new
                        {
                            Id = 4,
                            City = "Oakland",
                            FirstName = "Dean",
                            LastName = "Straight",
                            State = "CA"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<int>("ISBN")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 3,
                            Genre = 2,
                            ISBN = -123455811,
                            Title = "The Mystery of Shadows"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Genre = 1,
                            ISBN = -987653343,
                            Title = "The Fantasy Realm"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 4,
                            Genre = 3,
                            ISBN = -543210009,
                            Title = "Thrills and Chills"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 1,
                            Genre = 1,
                            ISBN = -567889145,
                            Title = "Enchanted Kingdom"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 4,
                            Genre = 2,
                            ISBN = -12344700,
                            Title = "Midnight Secrets"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.BookCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookCustomer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 2,
                            CustomerId = 1,
                            Genre = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            CustomerId = 2,
                            Genre = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 4,
                            CustomerId = 3,
                            Genre = 1
                        },
                        new
                        {
                            Id = 4,
                            BookId = 5,
                            CustomerId = 4,
                            Genre = 2
                        },
                        new
                        {
                            Id = 5,
                            BookId = 3,
                            CustomerId = 5,
                            Genre = 3
                        });
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St, Anytown, USA",
                            FirstName = "Alice",
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Address = "123 Main St, Anytown, USA",
                            FirstName = "Alice",
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak St, Smallville",
                            FirstName = "Carol",
                            LastName = "Davis"
                        },
                        new
                        {
                            Id = 4,
                            Address = "101 Pine St, Cityville",
                            FirstName = "David",
                            LastName = "Brown"
                        },
                        new
                        {
                            Id = 5,
                            Address = "222 Cedar St, Villageville",
                            FirstName = "Emily",
                            LastName = "White"
                        });
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.Book", b =>
                {
                    b.HasOne("BookStoreApp.Domain.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.BookCustomer", b =>
                {
                    b.HasOne("BookStoreApp.Domain.Models.Book", "Book")
                        .WithMany("BookCustomers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreApp.Domain.Models.Customer", "Customer")
                        .WithMany("BookCustomers")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.Book", b =>
                {
                    b.Navigation("BookCustomers");
                });

            modelBuilder.Entity("BookStoreApp.Domain.Models.Customer", b =>
                {
                    b.Navigation("BookCustomers");
                });
#pragma warning restore 612, 618
        }
    }
}
