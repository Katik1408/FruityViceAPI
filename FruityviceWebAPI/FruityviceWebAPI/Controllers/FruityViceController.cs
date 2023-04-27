using FruityViceDataContracts;
using FruityviceServices.Contract;
using Microsoft.AspNetCore.Mvc;

namespace FruityviceWebAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class FruityViceController : Controller
    {
        IFruityViceService fruityViceService;
        public FruityViceController(IFruityViceService fruityViceService)
        {
            this.fruityViceService = fruityViceService;
        }

        #region GETCalls
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll() =>
            Ok(this.fruityViceService.GetAllFruitsService());

        [HttpGet, Route("GetFruitsByNutrition/{nutrient}")]
        public IActionResult GetFruitsByNutrition(string nutrient, double min, double max) =>
            Ok(this.fruityViceService.GetFruitsByGetFruitsByNutritionService(nutrient, min, max));

        [HttpGet, Route("GetFruitsByFamily/{family}")]
        public IActionResult GetFruitsByFamily(string family) =>
            Ok(this.fruityViceService.GetFruitsByFamilyService(family));

        [HttpGet, Route("GetFruitsByGenus/{genus}")]
        public IActionResult GetFruitsByGenus(string genus) =>
            Ok(this.fruityViceService.GetFruitsByGenusService(genus));

        [HttpGet, Route("GetFruitsByOrder/{order}")]
        public IActionResult GetFruitsByOrder(string order) =>
            Ok(this.fruityViceService.GetFruitsByOrderService(order));

        #endregion


        [HttpPut, Route("AddNewFruit")]
        public IActionResult AddNewFruit([FromBody] FruitDto fruit)
        {
            var result = this.fruityViceService.AddNewFruitService(fruit);
            if (result.Contains("error"))
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
