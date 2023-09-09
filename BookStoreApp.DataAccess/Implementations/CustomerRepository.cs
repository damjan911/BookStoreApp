using BookStoreApp.DataAccess.Interfaces;
using BookStoreApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DataAccess.Implementations
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly BookStoreAppDbContext _dbContext;

        public CustomerRepository(BookStoreAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(Customer entity)
		{
			await _dbContext.Customers.AddAsync(entity);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteAsync(int? id)
		{
			Customer customerDb = new Customer();

			_dbContext.Customers.Remove(customerDb);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<List<Customer>> GetAllAsync()
		{
			return await _dbContext.Customers.ToListAsync();
		}

		public async Task<Customer> GetByIdAsync(int? id)
		{
			return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task UpdateAsync(Customer entity)
		{
			_dbContext.Customers.Update(entity);
			await _dbContext.SaveChangesAsync();
		}
	}
}
