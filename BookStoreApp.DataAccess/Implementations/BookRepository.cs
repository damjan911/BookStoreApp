using BookStoreApp.DataAccess.Interfaces;
using BookStoreApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DataAccess.Implementations
{
	public class BookRepository : IBookRepository
	{
		private readonly BookStoreAppDbContext _dbContext;

        public BookRepository(BookStoreAppDbContext dbContext)
        {
			_dbContext = dbContext;
        }
        public async Task CreateAsync(Book entity)
		{
			await _dbContext.Books.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int? id)
		{
			Book bookDb = new Book();

			_dbContext.Remove(bookDb);
			await _dbContext.SaveChangesAsync();
		}

		public List<Book> FilterBooks(int authorId, int isbn, IEnumerable<BookCustomer> bookCustomers)
		{
			if(authorId == 0 && isbn == 0 && bookCustomers == null)
			{
				return  _dbContext.Books.ToList();
			}

			if(authorId == 0)
			{
				List<Book> bookDb = _dbContext.Books.Where(x=>x.ISBN == isbn && x.BookCustomers == bookCustomers).ToList();
				return bookDb;
			}

			if(isbn == 0)
			{
				List<Book> bookDb = _dbContext.Books.Where(x=>x.AuthorId == authorId && x.BookCustomers == bookCustomers).ToList();
				return bookDb;
			}

			if(bookCustomers == null)
			{
				List<Book> bookDb = _dbContext.Books.Where(x => x.AuthorId == authorId && x.ISBN == isbn).ToList();
				return bookDb;
			}

			List<Book> books =  _dbContext.Books
				.Where(x => x.AuthorId == authorId && x.ISBN == isbn && x.BookCustomers == bookCustomers)
				.ToList();

			return books;
		}

		public async Task<List<Book>> GetAllAsync()
		{
			return await _dbContext.Books.ToListAsync();
		}

		public async Task<Book> GetByIdAsync(int? id)
		{
			return await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task UpdateAsync(Book entity)
		{
			_dbContext.Books.Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
