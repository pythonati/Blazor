using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerLogin : IRepositoryU3<LoginDBModel>
    {
        private readonly DB _context;

        public SQLServerLogin(DB context)
        {
            _context = context;
        }
        public LoginDBModel UserId(Dictionary<string, string> _params)
        {
            var _login = _context.Set<LoginDBModel>().FromSqlInterpolated($"exec dbo.sp_Login @login={_params["login"]}, @password={_params["password"]}, @loginType ={_params["loginType"]}").AsNoTracking();

            return _login?.FirstOrDefault();
        }
    }
}
