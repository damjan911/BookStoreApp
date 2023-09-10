using BookStoreApp.DTOs.AuthorDTOs;
using BookStoreApp.DTOs.BookDTOs;
using BookStoreApp.Services.Implementations;
using BookStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_App.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthorController : ControllerBase
     {
	 private readonly IAuthorService _authorService;

         public AuthorController(IAuthorService authorService)
           {
	      _authorService = authorService;
           }

	   [HttpGet("{id}")]

	    public async Task<ActionResult<AuthorDto>> GetAuthorByIdAsync(int? id)
	    {
		try
	         {
		    if (id == 0)
			{
			   return BadRequest("Id can not be null.");
			}

		    if (id <= 0)
			{
			    return BadRequest("Id can not be a negative number");
			}

		     AuthorDto authorDto = await _authorService.GetAuthorByIdAsync(id);

		     return Ok(authorDto);
		  }
		catch (Exception)
		 {
		    return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		 }
	     }

	    [HttpGet]

	    public async Task<ActionResult<List<AuthorDto>>> GetAllAuthorsAsync()
	      {
		 try
		  {
		      return Ok(await _authorService.GetAllAuthorsAsync());
		  }
		 catch (Exception)
		  {
		      return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		  }
		}

	      [HttpPost]

	      public async Task<ActionResult> CreateAuthorAsync([FromBody]CreateAuthorDto author)
		{
		  try
		   {
		     if (author == null || author.FirstName == null || author.LastName == null || author.City == null || author.State == null)
		     {
			return BadRequest("Invalid input");
		     }

		     await _authorService.CreateAuthorAsync(author);
		     return StatusCode(StatusCodes.Status201Created, "Author added");
		    }
		   catch (Exception)
		    {
			return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		    }
		}

	      [HttpDelete("{id}")]

	      public async Task<ActionResult> DeleteAuthorAsync(int id)
		{
		   try
		    {
			if (id == 0)
			{
			   return BadRequest("Id can not be null");
			}

			if (id <= 0)
			{
			    return BadRequest("Id can not be a negative number");
			}

			await _authorService.DeleteAuthorAsync(id);

			return Ok();
		      }
		     catch (Exception)
		      {
			return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		      }
		  }

		[HttpPatch("{id}")]

		public async Task<ActionResult> UpdateAuthorAsync([FromBody]CreateAuthorDto createAuthorDto, int id)
		{
		    try
		     {
			if (id == 0)
			{
			   return BadRequest("Id can not be null");
			}

			if (id <= 0)
			{
			    return BadRequest("Id can not be a negative number");
			}

			await _authorService.UpdateAuthorAsync(createAuthorDto, id);

			return Ok();
		      }
		     catch (Exception)
		      {
			  return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		      }
	          }
	}
}
