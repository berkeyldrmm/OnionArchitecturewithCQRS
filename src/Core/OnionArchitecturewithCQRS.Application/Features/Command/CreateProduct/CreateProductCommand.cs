using AutoMapper;
using MediatR;
using OnionArchitecturewithCQRS.Application.Exceptions;
using OnionArchitecturewithCQRS.Application.Interfaces.Repository;
using OnionArchitecturewithCQRS.Application.Interfaces.UnitOfWork;
using OnionArchitecturewithCQRS.Application.Wrappers;
using OnionArchitecturewithCQRS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecturewithCQRS.Application.Features.Command.CreateProduct
{
    public class CreateProductCommand: IRequest<ServiceResponse<Guid>>
    {
        private string _name;
        public String Name { get =>_name; set { _name = "arda"; } }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        
        public class CreateProductHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
               Product product = _mapper.Map<Product>(request);

                bool result = await _productRepository.AddEntity(product);

                if (!result)
                    throw new SqlException("An error occured while adding product.");

                int saved = await _productRepository.SaveChangesAsync();
                if(saved > 0)
                    return new ServiceResponse<Guid>(product.Id);

                throw new SqlException("Product entity couldn't add to database");

            }
        }
    }
}
