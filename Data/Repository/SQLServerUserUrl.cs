using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerUserUrl : IRepositoryU2<UserUrlDBModel>
    {
        private readonly DB _context;

        public SQLServerUserUrl(DB context)
        {
            _context = context;
        }
        public IEnumerable<UserUrlDBModel> Items(Dictionary<string, string> _params)
        {
            return _context.Set<UserUrlDBModel>().FromSqlInterpolated($"exec dbo.sp_UserUrls @pUserId={_params["userId"]}").AsNoTracking();
        }
    }
}
