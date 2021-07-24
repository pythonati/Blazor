using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerChart2 : IRepositoryU2<Chart2DBModel>
    {
        private readonly DB _context;

        public SQLServerChart2(DB context)
        {
            _context = context;
        }
        public IEnumerable<Chart2DBModel> Items(Dictionary<string, string> _params)
        {
            return _context.Set<Chart2DBModel>().FromSqlInterpolated($"exec dbo.sp_Chart2 @dateFrom={_params["dateFrom"]}, @dateTo={_params["dateTo"]}, @accountTypes={_params["accountTypes"]}, @categoryTypes = {_params["categoryTypes"]}, @labelTypes = {_params["labelTypes"]}").AsNoTracking();
        }
    }
}
