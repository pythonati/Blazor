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
    }
}
