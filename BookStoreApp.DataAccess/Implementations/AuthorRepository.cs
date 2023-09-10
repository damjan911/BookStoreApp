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
    public class AuthorRepository : IAuthorRepository
    {
	private readonly BookStoreAppDbContext _dbContext;

        public AuthorRepository(BookStoreAppDbContext dbContext)
        {
	     _dbContext = dbContext;
        }
        public async Task CreateAsync(Author entity)
	{
	    await _dbContext.Authors.AddAsync(entity);
	    await _dbContext.SaveChangesAsync();
	}

	public async Task DeleteAsync(int? id)
	{
	    Author authorDb = new Author();

	    _dbContext.Authors.Remove(authorDb);
	    await _dbContext.SaveChangesAsync();
	}

	public async Task<List<Author>> GetAllAsync()
	{
	    return await _dbContext.Authors.ToListAsync();
	}

	public async Task<Author> GetByIdAsync(int? id)
        {
	    return await _dbContext.Authors.FirstOrDefaultAsync(x=>x.Id == id);
	}

	public async Task UpdateAsync(Author entity)
	{
	    _dbContext.Authors.Update(entity);
	    await _dbContext.SaveChangesAsync();
	}
     }
}
