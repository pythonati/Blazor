using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerLogin : IRepositoryU2<LoginDBModel>
    {
        private readonly DB _context;

        public SQLServerLogin(DB context)
        {
            _context = context;
        }
        public IEnumerable<LoginDBModel> Items(Dictionary<string, string> _params)
        {
            return _context.Set<LoginDBModel>().FromSqlInterpolated($"exec dbo.sp_Login @login={_params["login"]}, @password={_params["password"]}").AsNoTracking();
        }
    }
}
