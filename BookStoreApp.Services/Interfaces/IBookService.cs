using BookStoreApp.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Interfaces
{
    public interface IBookService
    {
	 Task<BookDto> GetBookByIdAsync(int? id);

	 Task<IEnumerable<BookDto>> GetAllBooksAsync();

	 Task CreateBookAsync (CreateBookDto createBookDto);

	 Task DeleteBookAsync (int? id);

	 Task UpdateBookAsync (CreateBookDto createBookDto, int? id);
    }
}
