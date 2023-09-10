using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Domain.Models
{
   public class Author
   {
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	   
	[Required]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	public string LastName { get; set; } = string.Empty;
		
	public string? City { get; set; }

	public string? State { get; set; }


	public List<Book> Books = new List<Book>();
   }
}
