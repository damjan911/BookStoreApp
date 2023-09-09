using BookStoreApp.DataAccess.Interfaces;
using BookStoreApp.Domain.Models;
using BookStoreApp.DTOs.BookDTOs;
using BookStoreApp.Mappers;
using BookStoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Implementations
{
	public class BookService : IBookService
	{
		private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task CreateBookAsync(CreateBookDto book)
		{
			Book bookEntity = book.MapToBook();

			await _bookRepository.CreateAsync(bookEntity);
		}

		public async Task DeleteBookAsync(int? id)
		{
			await _bookRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
		{
			List<Book> books = await _bookRepository.GetAllAsync();

			if(books == null)
			{
				throw new NotImplementedException("Note is null.");
			}

			return books.Select(book=>book.MapToBookDto()).ToList();
		}

		public async Task<BookDto> GetBookByIdAsync(int? id)
		{
			Book book = await _bookRepository.GetByIdAsync(id);

			if (book == null)
			{
				throw new NotImplementedException("Book is null.");
			}

			return book.MapToBookDto();

		}

		public async Task UpdateBookAsync(CreateBookDto createBookDto, int? id)
		{
			Book bookDb = await _bookRepository.GetByIdAsync(id);

			if (bookDb == null)
			{
				throw new NotImplementedException("Book is null");
			}

			bookDb.Title = createBookDto.Title;
			bookDb.ISBN = (int)createBookDto.ISBN;
			bookDb.Genre = createBookDto.Genre;
			bookDb.AuthorId = createBookDto.AuthorId;
            
			await _bookRepository.UpdateAsync(bookDb);
		}
	}
}
