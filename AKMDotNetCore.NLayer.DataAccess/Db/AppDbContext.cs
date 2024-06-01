using Microsoft.EntityFrameworkCore;
using AKMDotNetCore.NLayer.DataAccess.Models;

namespace AKMDotNetCore.NLayer.DataAccess.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }


        public DbSet<BlogModel> Blogs { get; set; }
    }
}
