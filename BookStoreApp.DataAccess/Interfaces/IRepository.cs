﻿using BookStoreApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.DataAccess.Interfaces
{
	public interface IRepository<T>
	{
		Task<T> GetByIdAsync (int? id);

		Task<List<T>> GetAllAsync ();
		Task CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(int? id);
	}
}
