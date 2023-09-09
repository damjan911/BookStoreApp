using BookStoreApp.DataAccess.Interfaces;
using BookStoreApp.Domain.Models;
using BookStoreApp.DTOs.CustomerDTOs;
using BookStoreApp.Mappers;
using BookStoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Services.Implementations
{
	public class CustomerService : ICustomerService
	{
		private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
			_customerRepository = customerRepository;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto customer)
		{
			Customer customerEntity = customer.MapToCustomer();

			await _customerRepository.CreateAsync(customerEntity);
		}

		public async Task DeleteCustomerAsync(int? id)
		{
			await _customerRepository.DeleteAsync(id);
		}

		public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
		{
			List<Customer> customer = await _customerRepository.GetAllAsync();

			if (customer == null)
			{
				throw new NotImplementedException("Customer is null.");
			}

			return customer.Select(customer=>customer.MapToCustomerDto()).ToList();
		}

		public async Task<CustomerDto> GetCustomerByIdAsync(int? id)
		{
			Customer customer = await _customerRepository.GetByIdAsync(id);

			if (customer == null)
			{
				throw new NotImplementedException("Customer is null.");
			}

			return customer.MapToCustomerDto();
		}

		public async Task UpdateCustomerAsync(CreateCustomerDto createCustomerDto, int? id)
		{
			Customer customerDb = await _customerRepository.GetByIdAsync(id);

			if (customerDb == null)
			{
				throw new NotImplementedException("Customer is null.");
			}

			customerDb.FirstName = createCustomerDto.FirstName;
			customerDb.LastName = createCustomerDto.LastName;
			customerDb.Address = createCustomerDto.Address;

		}
	}
}
