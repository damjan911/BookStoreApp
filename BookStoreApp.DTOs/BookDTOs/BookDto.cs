using BookStoreApp.Domain.Enums;
using BookStoreApp.DTOs.AuthorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DTOs.BookDTOs
{
	public class BookDto
	{
		public string? Title { get; set; }

		public int? ISBN { get; set; }

		public Genre Genre { get; set; }

		public AuthorDto? Author { get; set; }
	}
}
