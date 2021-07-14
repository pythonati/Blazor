﻿using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using Microsoft.EntityFrameworkCore;

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
    }
}
