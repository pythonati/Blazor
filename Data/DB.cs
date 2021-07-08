using FirstBlazor.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazor.Data
{
    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
        public DbSet<TranDBModel> Trans { get; set; }
        public DbSet<AccountDBModel> Accounts { get; set; }
        public DbSet<CategoryDBModel> Category { get; set; }
    }
}
