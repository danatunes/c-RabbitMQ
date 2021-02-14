using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Entities
{
    public class BasketModel
    {
        public string Name { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        public BasketModel()
        {

        }

        public BasketModel(string name)
        {
            Name = name;
        }
    }
}
