﻿using OnionArchitecturewithCQRS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Application.Interfaces.Repository
{
    public interface IProductRepository: IGenericRepository<Product>
    {
    }
}
