using System;
using System.Collections.Generic;

namespace FirstBlazor.Interfaces
{
    public interface IRepositoryU1<T>
    {
        bool AddItem(T item);
        bool EditItem(T item)
        {
            throw new NullReferenceException();
        }
        IEnumerable<T> Items()
        {
            throw new NullReferenceException();
        }
        bool SaveChanges()
        {
            throw new NullReferenceException();
        }
    }
}
