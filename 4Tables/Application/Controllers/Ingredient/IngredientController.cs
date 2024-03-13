using _4Tables.Application.Controllers.Ingredient.Dto;
using _4Tables.Domain.Base.Common;
using _4Tables.Domain.Services.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.Application.Controllers.Ingredient
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {

        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<BasicResultT<List<IngredientDto>>>> FindAll()
        {
            var result = await _ingredientService.FindAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(new BasicResult().ERROR(new Error(System.Net.HttpStatusCode.BadRequest, "Erro na busca de ingredientes")));
        }

        [HttpPost]
        public async Task<ActionResult<BasicResultT<IEnumerable<string>>>> Create([FromBody] List<CreateIngredientDto> dtos)
        {
            var response = await _ingredientService.AddRange(dtos);

            return Ok(response);

        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<BasicResultT<IngredientDto>>> FindById([FromRoute] long id)
        {
            var result = await _ingredientService.FindById(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<BasicResult>> Delete([FromRoute] long id)
        {
            var result = await _ingredientService.Delete(id);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
