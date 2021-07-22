using System;
using System.Collections.Generic;

namespace FirstBlazor.Interfaces
{
    public interface IRepositoryU1<T>
    {
        bool AddItem(T item);
        IEnumerable<T> Items()
        {
            throw new NotImplementedException();
        }
        bool SaveChanges()
        {
            throw new NotImplementedException();
        }
        bool RemoveItem(T item)
        {
            throw new NotImplementedException();
        }
        T GetFirstItem()
        {
            throw new NotImplementedException();
        }
        T GetItemById(int id)
        {
            throw new NotImplementedException();
        }
        bool IsHaveLinksById(T item)
        {
            throw new NotImplementedException();
        }
    }
}
