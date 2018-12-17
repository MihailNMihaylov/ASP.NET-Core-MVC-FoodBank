using FoodBank.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Services.DataServices
{
    public interface IMarketService
    {
        IEnumerable<MarketViewModel> GetAll();

        int GetCount();

        Task<int> Create(string location);

    }
}
