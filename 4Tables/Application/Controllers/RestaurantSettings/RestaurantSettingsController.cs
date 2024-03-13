using _4Tables.Domain.Services.Product;
using _4Tables.Domain.Services.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace _4Tables.Application.Controllers.RestaurantSettings
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RestaurantSettingsController : ControllerBase
    {

        private readonly IRestaurantSettingsService _restaurantSettingsService;

        public RestaurantSettingsController(IRestaurantSettingsService restaurantSettingsService)
        {
            _restaurantSettingsService = restaurantSettingsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] int totalTables)
        {
            await _restaurantSettingsService.Add(totalTables);
            return Ok();
        }
    }
}
