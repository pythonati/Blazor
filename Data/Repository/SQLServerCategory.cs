using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlazor.Data.Repository
{
    public class SQLServerCategory : IRepositoryU1<CategoryDBModel>
    {
        private readonly DB _context;

        public SQLServerCategory(DB context)
        {
            _context = context;
        }

        public bool AddItem(CategoryDBModel item)
        {
            try
            {
                _context.Category.Add(item);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<CategoryDBModel> Items()
        {
            return _context.Category.ToList();
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
        public bool RemoveItem(CategoryDBModel item)
        {
            try
            {
                _context.Category.Remove(item);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public CategoryDBModel GetFirstItem()
        {
            return _context.Category.FirstOrDefault<CategoryDBModel>();
        }
    }
}
