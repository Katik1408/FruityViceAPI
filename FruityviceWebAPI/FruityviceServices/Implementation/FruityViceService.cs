using FruityViceDataContracts;
using FruityViceDataContracts.URIHelpers;
using FruityviceServices.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FruityviceServices.Implementation
{
    public class FruityViceService : IFruityViceService
    {
        private HttpClient _httpClient;

        public FruityViceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://www.fruityvice.com");

        }

        public string AddNewFruitService(FruitDto Fruit)
        {
            var data = JsonConvert.SerializeObject(Fruit);
            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");
            var result = _httpClient.PutAsync(ApiUrlConstants.Fruit, content);
            return result.ToString();
        }

        public List<FruitDto> GetAllFruitsService()
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.AllFruits).Result;
            return JsonConvert.DeserializeObject<List<FruitDto>>(data.Content.ReadAsStringAsync().Result);
        }

        public List<FruitDto> GetFruitsByFamilyService(string family)
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.FruitsByFamily + "/" + family).Result;
            return JsonConvert.DeserializeObject<List<FruitDto>>(data.Content.ReadAsStringAsync().Result);
        }

        public List<FruitDto> GetFruitsByGenusService(string genus)
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.FruitsByGenus + "/" + genus).Result;
            return JsonConvert.DeserializeObject<List<FruitDto>>(data.Content.ReadAsStringAsync().Result);
        }

        public List<FruitDto> GetFruitsByGetFruitsByNutritionService(string nutrient, double min, double max)
        {   
            string requestURI = ApiUrlConstants.Fruit + "/" + nutrient + $"?min={min}&max={max}";
            var data = _httpClient.GetAsync(requestURI).Result;
            return JsonConvert.DeserializeObject<List<FruitDto>>(data.Content.ReadAsStringAsync().Result);

        }

        public List<FruitDto> GetFruitsByOrderService(string order)
        {
            var data = _httpClient.GetAsync(ApiUrlConstants.FruitsByOrder + "/" + order).Result;
            return JsonConvert.DeserializeObject<List<FruitDto>>(data.Content.ReadAsStringAsync().Result);

        }
    }
}
