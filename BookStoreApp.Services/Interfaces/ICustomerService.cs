using BookStoreApp.DTOs.AuthorDTOs;
using BookStoreApp.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Interfaces
{
	public interface ICustomerService 
	{
		Task<CustomerDto> GetCustomerByIdAsync(int? id);

		Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();

		Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);

		Task DeleteCustomerAsync(int? id);

		Task UpdateCustomerAsync(CreateCustomerDto createCustomerDto, int? id);
	}
}
