using System;

namespace FruityViceDataContracts
{
    public class FruitDto
    {
        public string name { get; set; }
        public int id { get; set; }
        public string family { get; set; }
        public string order { get; set; }
        public string genus { get; set; }
        public Nutritions nutritions { get; set; }
    }



    public class Nutritions
    {
        public int calories { get; set; }
        public double fat { get; set; }
        public double sugar { get; set; }
        public double carbohydrates { get; set; }
        public double protein { get; set; }
    }




}
