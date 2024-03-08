﻿namespace BookShopping.WebApp.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetAsync(string url, int id);
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task<bool> CreateAsync(string url, T ObjToCreate);
        Task<bool> UpdateAsync(string url, T objToUpdate);
        Task<bool> DeleteAsync(string url, int id);
    }
}
