using AutoMapper;
using OnionArchitecturewithCQRS.Application.Dto;
using OnionArchitecturewithCQRS.Application.Features.Command.CreateProduct;
using OnionArchitecturewithCQRS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Application.Mapping
{
    public class ProductMapping: Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }
}
