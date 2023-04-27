using FruityViceDataContracts;
using FruityviceServices.Contract;
using FruityviceServices.Implementation;
using FruityviceWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using Xunit;

namespace Fruityvice.Tests
{

    public class FruityViceControllerTest
    {
        public readonly FruityViceController _controller;
        public readonly IFruityViceService _service;
        public readonly IHttpClientFactory _httpClientFactory;
        public FruityViceControllerTest()
        {

            _service = new FruityViceService(_httpClientFactory);
            _controller = new FruityViceController(_service);
        }

        [Fact]
        public void GetAllFruitTestCase()
        {

            var result = _controller.GetAll();
            Assert.IsType<OkResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetAllFruitByFamily()
        {
            string family = "Rosaceae";
            var result = _controller.GetFruitsByFamily(family);
            Assert.IsType<OkResult>(result as OkObjectResult);
        }


        [Fact]
        public void GetAllFruitByOrder()
        {
            string order = "Rosales";
            var result = _controller.GetFruitsByOrder(order);
            Assert.IsType<OkResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetAllFruitByGenus()
        {
            string genus = "Pyrus";
            var result = _controller.GetFruitsByGenus(genus);
            Assert.IsType<OkResult>(result as OkObjectResult);
        }

        [Fact]
        public void GetAllFruitByNutrients()
        {
            string bnutriens = "protein";
            double min = 5.5;
            double max = 10;
            var result = _controller.GetFruitsByNutrition(bnutriens, min, max);
            Assert.IsType<OkResult>(result as OkObjectResult);
        }

        [Fact]
        public void AddNewFruit()
        {
            FruitDto fruit = new FruitDto()
            {
                id = 1,
                family = "LionKing",
                genus = "Lion",
                name = "Simba",
                order = "Rosales",
                nutritions = new Nutritions()
                {
                    calories = 50,
                    carbohydrates = 50,
                    fat = 50,
                    protein = 50,
                    sugar = 50

                }
            };
            var result = _controller.AddNewFruit(fruit);
            Assert.IsType<OkResult>(result as OkObjectResult);
        }
    }
}
