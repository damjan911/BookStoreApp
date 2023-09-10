using BookStoreApp.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DataAccess.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
	List<Book> FilterBooks(int authorId,int isbn, IEnumerable<BookCustomer> BookCustomers);
    }
}
