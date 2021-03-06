using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerLogin : IRepositoryU3<ILoginDBModel>
    {
        private readonly DB _context;

        public SQLServerLogin(DB context)
        {
            _context = context;
        }
        public ILoginDBModel UserId(Dictionary<string, string> _params)
        {
            var _login = _context.Set<LoginDBModel>().FromSqlInterpolated($"exec dbo.sp_Login @pLogin={_params["Login"]}, @pPassword={_params["Password"]}, @pLoginType ={_params["LoginType"]}").AsNoTracking();

            LoginDBModel _result = new();

            foreach (var item in _login)
            {
                _result = item;
            }

            return _result;
        }
    }
}
