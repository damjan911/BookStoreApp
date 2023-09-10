using BookStoreApp.DTOs.AuthorDTOs;
using BookStoreApp.DTOs.BookDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Interfaces
{
    public interface IAuthorService 
    {
	  Task<AuthorDto> GetAuthorByIdAsync(int? id);

	  Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();

	  Task CreateAuthorAsync(CreateAuthorDto createAuthorDto);

	  Task DeleteAuthorAsync(int? id);

	  Task UpdateAuthorAsync(CreateAuthorDto createAuthorDto, int? id);
    }
}
