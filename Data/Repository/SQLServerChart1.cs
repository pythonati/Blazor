using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerChart1 : IRepositoryU2<Chart1DBModel>
    {
        private readonly DB _context;

        public SQLServerChart1(DB context)
        {
            _context = context;
        }
        public IEnumerable<Chart1DBModel> Items(Dictionary<string, string> _params)
        {
            return _context.Set<Chart1DBModel>().FromSqlInterpolated($"exec dbo.sp_Chart1 @dateFrom={_params["dateFrom"]}, @dateTo={_params["dateTo"]}, @accountTypes={_params["accountTypes"]}, @categoryTypes = {_params["categoryTypes"]}").AsNoTracking();
        }
    }
}
