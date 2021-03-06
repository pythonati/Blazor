using FirstBlazor.Interfaces;
using FirstBlazor.Models.DB;
using FirstBlazor.Models.DB.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FirstBlazor.Data
{
    public class DB: DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }
        public DbSet<TranDBModel> Trans { get; set; }
        public DbSet<AccountDBModel> Accounts { get; set; }
        public DbSet<CategoryDBModel> Category { get; set; }
        public DbSet<LableDBModel> Lables { get; set; }
        public DbSet<TransLablesModel> TransLables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransLablesModel>().HasKey(u => new { u.TransactionId, u.LableId });

            modelBuilder.Entity<Chart1DBModel>().HasNoKey().ToTable("Chart1DBModel", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Chart2DBModel>().HasNoKey().ToTable("Chart2DBModel", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<LoginDBModel>().HasNoKey().ToTable("LoginDBModel", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<UserUrlDBModel>().HasNoKey().ToTable("UserUrlDBModel", t => t.ExcludeFromMigrations());
        }
    }
}
