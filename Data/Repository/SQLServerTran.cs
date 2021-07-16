using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerTran: IRepositoryU1<TranDBModel>
    {
        private readonly DB _context;

        public SQLServerTran(DB context)
        {
            _context = context;
        }

        public bool AddItem(TranDBModel item)
        {
            try
            {
                _context.Trans.Add(item);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
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
        public IEnumerable<TranDBModel> Items()
        {
            return _context.Trans;
        }
        public bool RemoveItem(TranDBModel item)
        {
            try
            {
                _context.Trans.Remove(item);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public TranDBModel GetItemById(int id)
        {
            return _context.Trans.FirstOrDefaultAsync(i => i.Id == id).Result;
        }
    }
}
