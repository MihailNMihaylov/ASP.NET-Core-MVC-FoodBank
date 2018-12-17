using FoodBank.Data.Models;
using FoodBank.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodBank.Services.ViewModels
{
    public class MarketViewModel : IMapFrom<Market>
    {
        public int Id { get; set; }

        public string Location { get; set; }
    }
}
