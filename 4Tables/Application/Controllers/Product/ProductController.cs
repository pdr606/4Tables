using _4Tables.Application.Controllers.Ingredient.Dto;
using _4Tables.Application.Controllers.Product.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.Application.Controllers.Product
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<BasicResult>> Add([FromBody] CreateProductDto dto)
        {
            var result = await _productService.Add(dto);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result);
        }

        [HttpGet("Disables")]
        public async Task<ActionResult<BasicResultT<List<ProductDto>>>> FindAllDisables()
        {
            var result = await _productService.FindAllDisables();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<BasicResultT<List<ProductDto>>>> FindAll()
        {
            var result = await _productService.FindAll();

            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<BasicResultT<ProductDto>>> FindById([FromRoute] long id)
        {
            var result = await _productService.FindById(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<BasicResult>> Delete([FromRoute] long id)
        {
            var result = await _productService.Delete(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpPut("ActiveDesactive/{id:long}")]
        public async Task<ActionResult<BasicResult>> ActiveDesactive([FromRoute] long id)
        {
            var result = await _productService.ActiveDesactive(id);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return NotFound(result);
        }
    }
}
