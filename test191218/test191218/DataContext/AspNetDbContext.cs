using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test191218.Models;

namespace test191218.DataContext
{
    public class AspNetDbContext : DbContext
    {

        public DbSet<ComplexKey> ComplexKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplexKey>(e =>
            {
                e.HasKey(p => new { p.Key1, p.Key2 });
                e.ForMySQLHasCollation("utf8_general_ci");
                e.Property(p => p.Key1).ForMySQLHasCharset("utf8");
                e.Property(p => p.CollationColumn).ForMySQLHasCollation("utf8_general_ci");
            });
        }


        // db 자동생성용
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(@"Server=localhost;Database=AspNetNoteDb;Uid=root;Pwd=mysqlrootdev;"); // 오 된다 지난주 내내 왜 삽질 시킨거야..?? 왜 갑자기 되지?


        }

    }
}
