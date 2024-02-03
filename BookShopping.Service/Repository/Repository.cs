using BookShopping.Service.Data;
using BookShopping.Service.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping.Service.Repository
{
	public class Repository<T> : IRepostory<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext context)
        {
			_context = context;
			dbSet = _context.Set<T>();
        }
        public void Add(T entity)
		{
			dbSet.Add(entity);
			Save();
		}

		public T FirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if(filter != null)
				query = query.Where(filter);
			if(includeProperties != null)
				foreach(var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			return query.FirstOrDefault();
		}

		public T Get(int id)
		{
			return dbSet.Find(id);
		}

		public IEnumerable<T> GetAll(
			Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			string includeProperties = null)
		{

			IQueryable<T> query = dbSet;
			if (filter != null)
				query = query.Where(filter);
			if (includeProperties != null)
			{
				foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
				if (orderBy != null)
					return orderBy(query);
			}
			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
			Save();
		}
		public void Remove(int id )
		{
			var entity = Get(id);
			Remove(entity);
		}
		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
			Save();
		}

        public void Save()
        {
			_context.SaveChanges();
        }

        public void Update(T entity)
		{
			dbSet.Update(entity);
			Save();
		}
	}
}
