using BookStoreApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DTOs.BookDTOs
{
   public class CreateBookDto
   {
	public string? Title { get; set; }

	public int? ISBN { get; set; }

	public Genre Genre { get; set; }

	public int AuthorId { get; set; }
   }
}
