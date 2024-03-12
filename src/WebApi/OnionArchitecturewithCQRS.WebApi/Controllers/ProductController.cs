using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecturewithCQRS.Application.Dto;
using OnionArchitecturewithCQRS.Application.Exceptions;
using OnionArchitecturewithCQRS.Application.Features.Command.CreateProduct;
using OnionArchitecturewithCQRS.Application.Features.Query.GetAllProducts;
using OnionArchitecturewithCQRS.Application.Features.Query.GetProductById;
using OnionArchitecturewithCQRS.Application.Interfaces.Repository;
using OnionArchitecturewithCQRS.Application.Interfaces.UnitOfWork;
using OnionArchitecturewithCQRS.Application.Wrappers;
using OnionArchitecturewithCQRS.Domain.Entites;
using OnionArchitecturewithCQRS.Persistence.UnitOfWorkService;

namespace OnionArchitecturewithCQRS.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<ProductDto>> response = await _mediator.Send(new GetAllProductsQuery());

            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            ServiceResponse<ProductDto> response = await _mediator.Send(new GetProductQuery(id));
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            ServiceResponse<Guid> response = await _mediator.Send(command);
            int result = await _unitOfWork.SaveChangesAsync();

            if(result > 0)
                return Ok(response);

            throw new SqlException("Product entity couldn't add to database");
        }
    }
}
