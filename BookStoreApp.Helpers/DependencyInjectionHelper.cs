using BookStoreApp.DataAccess;
using BookStoreApp.DataAccess.Implementations;
using BookStoreApp.DataAccess.Interfaces;
using BookStoreApp.Domain.Models;
using BookStoreApp.Services.Implementations;
using BookStoreApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Helpers
{
    public static class DependencyInjectionHelper
    {
	 public static void InjectDbContext (this IServiceCollection services)
	 {
	      services.AddDbContext<BookStoreAppDbContext> (options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLServer;Database=BookStoreApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
	 }

	 public static void InjectRepositories(this IServiceCollection services)
	 {
		services.AddTransient<IRepository<Book>, BookRepository>();
		services.AddTransient<IRepository<Author>, AuthorRepository>();
		services.AddTransient<IRepository<Customer>, CustomerRepository>();
	 }

	public static void InjectServices (this IServiceCollection services)
	{
		services.AddTransient<IBookService, BookService>();
		services.AddTransient<IAuthorService, AuthorService>();
		services.AddTransient<ICustomerService, CustomerService>();
	}
     }
}
