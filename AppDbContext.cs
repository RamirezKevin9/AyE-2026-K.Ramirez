using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class AppDbContext : DbContext
    {
        public DbSet<vector> vector { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=localhost;Database=vector2d;Uid=root;pwd=;";
            var serverVersion = ServerVersion.AutoDetect(connection);
            optionsBuilder.UseMySql(connection, serverVersion);
        }
    }
}
