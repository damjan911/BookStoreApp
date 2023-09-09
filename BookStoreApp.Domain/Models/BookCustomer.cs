using BookStoreApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Models
{
	public class BookCustomer 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public Customer? Customer { get; set; }

		public int CustomerId { get; set; }

		public Book? Book { get; set; }

		public int BookId { get; set; }

		public Genre Genre { get; set; }
	}
}
