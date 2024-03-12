using Microsoft.EntityFrameworkCore;
using OnionArchitecturewithCQRS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Persistence.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions builder): base(builder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Book", Quantity = 200, Value = 60 },
                    new Product { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Notebook", Quantity = 100, Value = 30 },
                    new Product { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Pen", Quantity = 500, Value = 20 },
                    new Product { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Paper A4", Quantity = 1000, Value = 1 },
                    new Product { Id = Guid.NewGuid(), CreateDate = DateTime.UtcNow, Name = "Bag", Quantity = 30, Value = 300 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
