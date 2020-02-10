using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kalinkin.MyTog.Mobile
{
    public interface IRepository<T>
    {
        Task<bool> InsertItem(T item);
        Task<bool> InsertItems(IEnumerable<T> items);
        Task<IEnumerable<T>> GetAllItems();
        Task<T> GetItem(string pk);
        Task<T> GetItem(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindItems(Expression<Func<T, bool>> predicate);
        Task<bool> AddItem(T item);
        Task<bool> UpdateItem(T item);
        Task<bool> DeleteItem(T item);
    }
}