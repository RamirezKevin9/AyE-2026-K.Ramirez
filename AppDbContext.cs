using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ConsoleApp18
{
    internal class AppDbContext : DbContext
    {
        public DbSet<pokedex> pokemon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server=localhost;Database=pokedex;Uid=root;pwd=;";

            var serverVersion = ServerVersion.AutoDetect(connection);

            optionsBuilder.UseMySql(connection, serverVersion);
        }
    }
}