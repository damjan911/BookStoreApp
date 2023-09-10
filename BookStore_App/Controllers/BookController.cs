using BookStoreApp.DTOs.BookDTOs;
using BookStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
     {
	   private readonly IBookService _bookService;

	   public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

	    [HttpGet("{id}")]

	     public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
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

			 BookDto bookDto = await _bookService.GetBookByIdAsync(id);

			 return Ok(bookDto);
		    }
		   catch (Exception)
		    {
			return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		    }
	        }

	      [HttpGet]

	       public async Task<ActionResult<List<BookDto>>> GetAllBooksAsync()
	       {
		   try
		    {
			 return Ok(await _bookService.GetAllBooksAsync());
		    }
		    catch (Exception)
		    {
			return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		    }
		}

		[HttpPost]

		public async Task<ActionResult> CreateBookAsync([FromBody]CreateBookDto book)
		 {
		     try
		      {
			  if (book == null || book.Title == null || book.ISBN == 0 || book.Genre == 0 || book.AuthorId == 0)
			   {
				return BadRequest("Invalid input");
			   }

			  await _bookService.CreateBookAsync(book);
			  return StatusCode(StatusCodes.Status201Created, "Book added");
			}
		     catch (Exception)
		       {
			   return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		       }
		 }

		[HttpDelete("{id}")]

		public async Task<ActionResult> DeleteBookAsync(int id)
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

			await _bookService.DeleteBookAsync(id);

			return Ok();
		    }
		   catch (Exception)
		     {
			  return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		     }
		 }

		[HttpPatch("{id}")]

		public async Task<ActionResult> UpdateBookAsync ([FromBody]CreateBookDto createBookDto, int id)
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

			await _bookService.UpdateBookAsync(createBookDto, id);

			return Ok();
		    }
		   catch (Exception)
		    {
			return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
		    }
		}
	}
}
