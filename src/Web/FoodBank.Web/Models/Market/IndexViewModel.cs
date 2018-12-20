using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodBank.Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<IndexMarketViewModel> Markets { get; set; }
    }
}
