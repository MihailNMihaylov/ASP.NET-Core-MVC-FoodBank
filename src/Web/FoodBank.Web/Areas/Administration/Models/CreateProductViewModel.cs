using FoodBank.Data.Models;
using FoodBank.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBank.Web.Areas.Administration.Models
{
    public class CreateProductViewModel : IMapTo<Product>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
