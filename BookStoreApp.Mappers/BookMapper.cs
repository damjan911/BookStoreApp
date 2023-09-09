using BookStoreApp.Domain.Models;
using BookStoreApp.DTOs.AuthorDTOs;
using BookStoreApp.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Mappers
{
	public static class BookMapper
	{
		public static BookDto MapToBookDto (this Book book)
		{
			return new BookDto()
			{
				Title = book.Title,
				ISBN = book.ISBN,
				Genre = book.Genre,
				Author = book.Author == null ? new AuthorDto() : book.Author.MapToAuthorDto()
			};
		}

		public static Book MapToBook (this CreateBookDto createBookDto)
		{
			return new Book()
			{
				Title = createBookDto.Title,
				ISBN = (int)createBookDto.ISBN,
				Genre = createBookDto.Genre,
				AuthorId = createBookDto.AuthorId
			};
		}
	}
}
