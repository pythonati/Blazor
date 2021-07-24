using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using System.Collections.Generic;
using System.Linq;

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

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<AccountDBModel> Items()
        {
            return _context.Accounts;
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
        public bool RemoveItem(AccountDBModel item)
        {
            try
            {
                _context.Accounts.Remove(item);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public AccountDBModel GetFirstItem()
        {
            return _context.Accounts.FirstOrDefault<AccountDBModel>();
        }
        public bool IsHaveLinksById(AccountDBModel item)
        {
            if (_context.Trans.FirstOrDefault(i => i.AccountId == item.Id) is null)
            {
                return false;
            }

            return true;
        }
    }
}
