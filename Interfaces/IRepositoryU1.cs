using System;
using System.Collections.Generic;

namespace FirstBlazor.Interfaces
{
    public interface IRepositoryU1<T>
    {
        bool AddItem(T item);
        IEnumerable<T> Items()
        {
            throw new NullReferenceException();
        }
        bool SaveChanges()
        {
            throw new NullReferenceException();
        }
        bool RemoveItem(T item)
        {
            throw new NullReferenceException();
        }
        T GetFirstItem()
        {
            throw new NullReferenceException();
        }
        T GetItemById(int id)
        {
            throw new NullReferenceException();
        }
    }
}
