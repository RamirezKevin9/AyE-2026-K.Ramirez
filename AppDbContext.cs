using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class AppDbContext : DbContext
    {
        public DbSet<inventario> inventario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=localhost;Database=laboratorio;Uid=root;pwd=;";
            var serverVersion = ServerVersion.AutoDetect(connection);
            optionsBuilder.UseMySql(connection, serverVersion);
        }
    }

}
