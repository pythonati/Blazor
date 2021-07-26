using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using System.Collections.Generic;
using System.Linq;

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
        public void Explicit_Loading(TranDBModel item)
        {
            _context.Entry(item).Collection("Lables").Load();

            if (item.Lables is not null)
            {
                foreach(var lable in item.Lables)
                {
                    lable.Lable = _context.Lables?.FirstOrDefault(i => i.Id == lable.LableId) ?? new();
                }
            }
        }
    }
}
