using BookStoreApp.DTOs.AuthorDTOs;
using BookStoreApp.DTOs.CustomerDTOs;
using BookStoreApp.Services.Implementations;
using BookStoreApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_App.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{

			_customerService = customerService;
		}

		[HttpGet("{id}")]

		public async Task<ActionResult<CustomerDto>> GetCustomerByIdAsync(int? id)
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

				CustomerDto customerDto = await _customerService.GetCustomerByIdAsync(id);

				return Ok(customerDto);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}

		}

		[HttpGet]

		public async Task<ActionResult<List<CustomerDto>>> GetAllCustomersAsync()
		{
			try
			{
				return Ok(await _customerService.GetAllCustomersAsync());
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpPost]

		public async Task<ActionResult> CreateCustomerAsync([FromBody]CreateCustomerDto customer)
		{
			try
			{
				if (customer == null || customer.FirstName == null || customer.LastName == null || customer.Address == null)
				{
					return BadRequest("Invalid input");
				}

				await _customerService.CreateCustomerAsync(customer);
				return StatusCode(StatusCodes.Status201Created, "Customer added");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}

		[HttpDelete("{id}")]

		public async Task<ActionResult> DeleteCustomerAsync(int id)
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

				await _customerService.DeleteCustomerAsync(id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}

		}

		[HttpPatch("{id}")]

		public async Task<ActionResult> UpdateCustomerAsync([FromBody]CreateCustomerDto createCustomerDto, int id)
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

				await _customerService.UpdateCustomerAsync(createCustomerDto, id);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Please contact the support team.");
			}
		}
	}
}
