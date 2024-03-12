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

namespace OnionArchitecturewithCQRS.Application.Features.Query.GetAllProducts
{
    public class GetAllProductsQuery: IRequest<ServiceResponse<List<ProductDto>>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductDto>>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                List<Product> products = await _productRepository.GetAll();

                List<ProductDto> dto = _mapper.Map<List<ProductDto>>(products);

                return new ServiceResponse<List<ProductDto>>(dto);
            }
        }
    }
}
