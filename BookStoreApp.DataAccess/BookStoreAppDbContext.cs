using BookStoreApp.Domain.Enums;
using BookStoreApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DataAccess
{
	public class BookStoreAppDbContext : DbContext
	{
		public BookStoreAppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{

		}

		public DbSet<Author> Authors { get; set; }

		public DbSet<Book> Books { get; set; }

		public DbSet<Customer> Customers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Author>()
			.Property(x => x.FirstName)
			.HasMaxLength(50);

			modelBuilder.Entity<Author>()
			.Property(x => x.LastName)
			.HasMaxLength(50);

			modelBuilder.Entity<Author>()
			.Property(x => x.City)
			.HasMaxLength(50);

			modelBuilder.Entity<Author>()
			.Property(x => x.State)
			.HasMaxLength(50);


			modelBuilder.Entity<Book>()
			.Property(x => x.Title)
			.HasMaxLength(50);

			modelBuilder.Entity<Book>()
			.Property(x => x.ISBN)
			.HasMaxLength(50);

			modelBuilder.Entity<Book>()
			.Property(x => x.Genre)
			.IsRequired();

			modelBuilder.Entity<Customer>()
			.Property(x => x.FirstName)
			.HasMaxLength(50);

			modelBuilder.Entity<Customer>()
			.Property(x => x.LastName)
			.HasMaxLength(50);

			modelBuilder.Entity<Customer>()
			.Property(x => x.Address)
			.IsRequired();

			modelBuilder.Entity<Book>()
			.HasMany(x => x.BookCustomers)
			.WithOne(x => x.Book)
			.HasForeignKey(x => x.BookId);

			modelBuilder.Entity<Customer>()
			.HasMany(x => x.BookCustomers)
			.WithOne(x => x.Customer)
			.HasForeignKey(x => x.BookId);

			modelBuilder.Entity<Author>()
			.HasMany(x => x.Books)
			.WithOne(x => x.Author)
			.HasForeignKey(x => x.AuthorId);

			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 1,
				FirstName = "Abraham",
				LastName = "Bennet",
				City = "Berkeley",
				State = "CA"
			});

			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 2,
				FirstName = "Johnson",
				LastName = "White",
				City = "Menlo Park",
				State = "CA"
			});

			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 3,
				FirstName = "Charlene",
				LastName = "Locksley",
				City = "San Francisco",
				State = "CA"
			});

			modelBuilder.Entity<Author>().HasData(new Author
			{
				Id = 4,
				FirstName = "Dean",
				LastName = "Straight",
				City = "Oakland",
				State = "CA"
			});

			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 1,
				Title = "The Mystery of Shadows",
				ISBN = 978 - 123456789,
				Genre = Domain.Enums.Genre.Mystery,
				AuthorId = 3
			});

			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 2,
				Title = "The Fantasy Realm",
				ISBN = 978 - 987654321,
				Genre = Domain.Enums.Genre.Fantasy,
				AuthorId = 2
			});

			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 3,
				Title = "Thrills and Chills",
				ISBN = 978 - 543210987,
				Genre = Domain.Enums.Genre.Thriller,
				AuthorId = 4
			});

			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 4,
				Title = "Enchanted Kingdom",
				ISBN = 978 - 567890123,
				Genre = Domain.Enums.Genre.Fantasy,
				AuthorId = 1
			});

			modelBuilder.Entity<Book>().HasData(new Book
			{
				Id = 5,
				Title = "Midnight Secrets",
				ISBN = 978 - 012345678,
				Genre = Domain.Enums.Genre.Mystery,
				AuthorId = 4
			});

			modelBuilder.Entity<Customer>().HasData(new Customer
			{
				Id = 1,
				FirstName = "Alice",
				LastName = "Johnson",
				Address = "123 Main St, Anytown, USA"
			});

			modelBuilder.Entity<Customer>().HasData(new Customer
			{
				Id = 2,
				FirstName = "Alice",
				LastName = "Johnson",
				Address = "123 Main St, Anytown, USA"
			});

			modelBuilder.Entity<Customer>().HasData(new Customer
			{
				Id = 3,
				FirstName = "Carol",
				LastName = "Davis",
				Address = "789 Oak St, Smallville"
			});

			modelBuilder.Entity<Customer>().HasData(new Customer
			{
				Id = 4,
				FirstName = "David",
				LastName = "Brown",
				Address = "101 Pine St, Cityville"
			});

			modelBuilder.Entity<Customer>().HasData(new Customer
			{
				Id = 5,
				FirstName = "Emily",
				LastName = "White",
				Address = "222 Cedar St, Villageville"
			});

			modelBuilder.Entity<BookCustomer>().HasData(new BookCustomer
			{
				Id = 1,
				CustomerId = 1,
				BookId = 2,
				Genre = Genre.Fantasy
			});

			modelBuilder.Entity<BookCustomer>().HasData(new BookCustomer
			{
				Id = 2,
				CustomerId = 2,
				BookId = 1,
				Genre = Genre.Mystery
			});

			modelBuilder.Entity<BookCustomer>().HasData(new BookCustomer
			{
				Id = 3,
				CustomerId = 3,
				BookId = 4,
				Genre = Genre.Fantasy
			});

			modelBuilder.Entity<BookCustomer>().HasData(new BookCustomer
			{
				Id = 4,
				CustomerId = 4,
				BookId = 5,
				Genre = Genre.Mystery
			});

			modelBuilder.Entity<BookCustomer>().HasData(new BookCustomer
			{
				Id = 5,
				CustomerId = 5,
				BookId = 3,
				Genre = Genre.Thriller
			});

		}

	}
}
