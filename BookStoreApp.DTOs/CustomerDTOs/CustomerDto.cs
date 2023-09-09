using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DTOs.CustomerDTOs
{
	public class CustomerDto
	{
		public string FirstName { get; set; } = string.Empty;

		public string LastName { get; set; } = string.Empty;

		public string? Address { get; set; }
	}
}
