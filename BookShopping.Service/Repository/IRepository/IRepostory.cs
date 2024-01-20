using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShopping.Service.Repository.IRepository
{
	public interface IRepostory<T> where T : class
	{
		void Add(T entity);
		void Update(T entity);
		void Remove(T entity);
		void Remove(int id);
		void RemoveRange(IEnumerable<T> entity);
		T Get(int id);
		IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
			string includeProperties = null);//Categories, CoverType
		T FirstOrDefault(Expression<Func<T, bool>> filter = null,
			string includePropties = null); //Categories, CoverType
	}
}
