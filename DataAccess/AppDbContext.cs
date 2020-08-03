using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Word> Words { get; set; }
        public DbSet<Definition> Definitions { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Example> Examples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WordConfig());
            modelBuilder.ApplyConfiguration(new DefinitionConfig());
            modelBuilder.ApplyConfiguration(new DescriptionConfig());
            modelBuilder.ApplyConfiguration(new ExampleConfig());
        }
    }
}
