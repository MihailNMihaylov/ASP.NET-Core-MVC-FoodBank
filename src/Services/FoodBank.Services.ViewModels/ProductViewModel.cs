using FoodBank.Data.Models;
using FoodBank.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodBank.Services.ViewModels
{
    public class ProductViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
