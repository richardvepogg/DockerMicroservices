using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Products.Queries.GetAllProducts;
using ProductService.Application.Products.Queries.GetProduct;
using ProductService.Application.Products.Command.CreateProduct;
using ProductService.WebApi.Features.Products.GetProduct;
using ProductService.WebApi.Features.Products.CreateProduct;
using ProductService.WebApi.Features.Products.UpdateProduct;
using ProductService.Application.Products.Command.UpdateProduct;
using ProductService.Application.Products.Command.DeleteProduct;
using ProductService.WebApi.Features.Products.GetAllProducts;
using ProductService.WebApi.Features.Products.GetPriceDifference;
using ProductService.Application.Products.Queries.PriceDifference;
using ProductService.Controllers.Common;
using ProductService.WebApi.Features.Products.DeleteProduct;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [Authorize(Roles = "Employe, Manager")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            try
            {
                GetAllProductsResult result = await _mediator.Send(new GetAllProductsQuerie(), cancellationToken);

                GetAllProductsResponse response = _mapper.Map<GetAllProductsResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet("PriceDifference{id}")]
        public async Task<IActionResult> GetPriceDifference([FromRoute] int id, [FromQuery] PriceDifferenceRequest product, CancellationToken cancellationToken)
        {
            try
            {
                PriceDifferenceQuerie querie = _mapper.Map<PriceDifferenceQuerie>(product);

                PriceDifferenceResult result = await _mediator.Send(querie, cancellationToken);

                if (result == null) return BadRequest("Failed to get price difference");

                var response = _mapper.Map<PriceDifferenceResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Employe, Manager")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
        {
            try
            {
                GetProductRequest request = new GetProductRequest { Id = id };

                GetProductQuerie querie = _mapper.Map<GetProductQuerie>(request.Id);
                GetProductResult result = await _mediator.Send(querie, cancellationToken);

                if (result == null) return NotFound();

                var response = _mapper.Map<GetProductResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequest product, CancellationToken cancellationToken)
        {
            try
            {
                CreateProductCommand command = _mapper.Map<CreateProductCommand>(product);

                CreateProductResult result = await _mediator.Send(command, cancellationToken);

                if (result == null) return BadRequest("Failed to create product");

                var response = _mapper.Map<GetProductResponse>(result);
                return Created("GetProduct", new {response.id}, response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest product, CancellationToken cancellationToken)
        {
            try
            {
                UpdateProductCommand command = _mapper.Map<UpdateProductCommand>(product);

                UpdateProductResult? result = await _mediator.Send(command, cancellationToken);

                if (result == null) return BadRequest("Failed to update product");

                var response = _mapper.Map<UpdateProductResponse>(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            try
            {
                DeleteProductRequest request = new DeleteProductRequest { Id = id };
                DeleteProductCommand command = _mapper.Map<DeleteProductCommand>(request.Id);

                DeleteProductResult result = await _mediator.Send(command, cancellationToken);

                if (result.Success)
                    return Ok("The product was successfully deleted!");

                return NotFound("Product not found");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}