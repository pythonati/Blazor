using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerAccount : IRepositoryU1<AccountDBModel>
    {
        private readonly DB _context;

        public SQLServerAccount(DB context)
        {
            _context = context;
        }

        public bool AddItem(AccountDBModel item)
        {
            try
            {
                _context.Accounts.Add(item);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditItem(AccountDBModel item)
        {
            try
            {
                var _item = _context.Accounts.Attach(item);
                _item.State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<AccountDBModel> Items()
        {
            return _context.Accounts.ToList();
        }
    }
}
