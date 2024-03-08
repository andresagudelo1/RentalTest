﻿namespace Rentadora.Rental.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task UpdateAsync(T entity);
        Task Delete(T entity);
        Task<T> GetSequence(T entity);
        void UpdateSync(T entity);
        Task DeleteRange(T[] entity);
    }
}
