using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Interfaces
{
    interface IRepositoryU2<T>
    {
        IEnumerable<T> Items(Dictionary<string, string> _params);
   }
}
