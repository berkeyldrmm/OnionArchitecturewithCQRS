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
    public class GetProductHandler : IRequestHandler<GetProductQuery, ServiceResponse<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            Product p = await _productRepository.GetById(request.Id);
            ProductDto productDto = _mapper.Map<ProductDto>(p);
            return new ServiceResponse<ProductDto>(productDto);
        }
    }
}
