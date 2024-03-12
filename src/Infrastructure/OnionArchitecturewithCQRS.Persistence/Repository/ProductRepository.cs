using OnionArchitecturewithCQRS.Application.Interfaces.Repository;
using OnionArchitecturewithCQRS.Domain.Entites;
using OnionArchitecturewithCQRS.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Persistence.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
