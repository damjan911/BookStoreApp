using BookStoreApp.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Models
{
	public class Book 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string? Title { get; set; }

		[Required]
		public int ISBN { get; set; }

		[Required]
		public Genre Genre { get; set; }

		[ForeignKey("Author")]
		public int AuthorId { get; set; }

		public Author? Author { get; set; }

		public List<BookCustomer> BookCustomers = new List<BookCustomer>();
	}
}
