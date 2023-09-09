using BookStoreApp.Domain.Models;
using BookStoreApp.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Mappers
{
	public static class CustomerMapper
	{
		public static CustomerDto MapToCustomerDto (this Customer customer)
		{
			return new CustomerDto()
			{
				FirstName = customer.FirstName,
				LastName = customer.LastName,
				Address = customer.Address
			};
		}

		public static Customer MapToCustomer (this CreateCustomerDto createCustomerDto)
		{
			return new Customer()
			{
				FirstName = createCustomerDto.FirstName,
				LastName = createCustomerDto.LastName,
				Address = createCustomerDto.Address
			};
		}
	}
}
