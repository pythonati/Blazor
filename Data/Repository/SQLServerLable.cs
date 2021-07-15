using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerLable: IRepositoryU1<LableDBModel>
    {
        private readonly DB _context;

        public SQLServerLable(DB context)
        {
            _context = context;
        }

        public bool AddItem(LableDBModel item)
        {
            try
            {
                _context.Lables.Add(item);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<LableDBModel> Items()
        {
            return _context.Lables;
        }

        public bool SaveChanges()
        {
            try
            {
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveItem(LableDBModel item)
        {
            try
            {
                _context.Lables.Remove(item);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
