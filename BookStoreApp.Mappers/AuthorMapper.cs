using BookStoreApp.Domain.Models;
using BookStoreApp.DTOs.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Mappers
{
    public static class AuthorMapper
    {
	  public static AuthorDto MapToAuthorDto (this Author author)
	  {
	      return new AuthorDto()
	      {
		    FirstName = author.FirstName,
		    LastName = author.LastName,
		    City = author.City,
		    State = author.State
	       };
          }

	   public static Author MapToAuthor (this CreateAuthorDto createAuthorDto)
	   {
		return new Author()
		{
		     FirstName = createAuthorDto.FirstName,
		     LastName = createAuthorDto.LastName,
		     City = createAuthorDto.City,
		     State = createAuthorDto.State
		};
	    }
	}
}
