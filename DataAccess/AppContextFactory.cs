using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace DataAccess
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<AppDbContext> builder = new DbContextOptionsBuilder<AppDbContext>();
            string connectionString = @"Server=DESKTOP-1SBNOEE;Database=EnglishApp;Trusted_Connection=True;MultipleActiveResultSets=true";
            builder.UseLazyLoadingProxies().UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
