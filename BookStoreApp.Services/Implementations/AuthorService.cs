using BookStoreApp.DataAccess.Interfaces;
using BookStoreApp.Domain.Models;
using BookStoreApp.DTOs.AuthorDTOs;
using BookStoreApp.Mappers;
using BookStoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
	 private readonly IRepository<Author> _authorRepository;

         public AuthorService(IRepository<Author> authorRepository)
         {
            _authorRepository = authorRepository;
         }
         public async Task CreateAuthorAsync(CreateAuthorDto author)
	 {
	    Author authorEntity = author.MapToAuthor();

	    await _authorRepository.CreateAsync(authorEntity);
	 }

	 public async Task DeleteAuthorAsync(int? id)
	 {
	     await _authorRepository.DeleteAsync(id);
	 }

	  public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
	  {
		List<Author> author = await _authorRepository.GetAllAsync();

		if(author == null)
		{
		     throw new NotImplementedException("Author is null.");
		}

		return author.Select(author => author.MapToAuthorDto()).ToList();
	   }

	    public async Task<AuthorDto> GetAuthorByIdAsync(int? id)
	    {
		  Author author = await _authorRepository.GetByIdAsync(id);

		  if (author == null)
		  {
			throw new NotImplementedException("Author is null.");
		  }

		  return author.MapToAuthorDto();
	     }

	    public async Task UpdateAuthorAsync(CreateAuthorDto createAuthorDto, int? id)
	    {
		 Author authorDb = await _authorRepository.GetByIdAsync(id);

		 if (authorDb == null)
		 {
		      throw new NotImplementedException("Author is null.");
		 }

		 authorDb.FirstName = createAuthorDto.FirstName;
		 authorDb.LastName = createAuthorDto.LastName;
		 authorDb.City = createAuthorDto.City;
		 authorDb.State = createAuthorDto.State;

	    }
	 }
}
