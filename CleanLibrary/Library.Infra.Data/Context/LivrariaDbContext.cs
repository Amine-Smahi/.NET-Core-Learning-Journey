using Library.Domain.Entities;
using Livraria.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Livraria.Infra.Data.Context
{
    public class LivrariaDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editor> Editors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            optionsBuilder.UseInMemoryDatabase(databaseName: "LibraryDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(new BookMap().Configure);
            modelBuilder.Entity<Autor>(new AutorMap().Configure);
            modelBuilder.Entity<Editor>(new EditorMap().Configure);
        }
    }
}
