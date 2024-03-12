using AutoMapper;
using MediatR;
using OnionArchitecturewithCQRS.Application.Dto;
using OnionArchitecturewithCQRS.Application.Interfaces.Repository;
using OnionArchitecturewithCQRS.Application.Wrappers;
using OnionArchitecturewithCQRS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Application.Features.Query.GetProductById
{
    public class GetProductQuery: IRequest<ServiceResponse<ProductDto>>
    {
        public Guid Id { get; set; }
        public GetProductQuery(Guid id)
        {
            Id = id;
        }
    }
}
