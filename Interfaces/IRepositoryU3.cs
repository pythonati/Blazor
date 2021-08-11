using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Interfaces
{
    interface IRepositoryU3<T>
    {
        T UserId(Dictionary<string, string> _params);
   }
}
