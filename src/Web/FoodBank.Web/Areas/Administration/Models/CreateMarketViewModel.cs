using FoodBank.Data.Models;
using FoodBank.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBank.Web.Areas.Administration.Models
{
    public class CreateMarketViewModel : IMapTo<Market>
    {
        public string Location { get; set; }
    }
}
