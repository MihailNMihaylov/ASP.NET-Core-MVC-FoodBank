using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Data.Common;
using FoodBank.Data.Models;
using FoodBank.Services.Mapping;
using FoodBank.Services.ViewModels;

namespace FoodBank.Services.DataServices
{
    public class MarketService : IMarketService
    {
        private readonly IRepository<Market> marketRepository;

        public MarketService(IRepository<Market> marketRepository)
        {
            this.marketRepository = marketRepository;
        }

        public async Task<int> Create(string location)
        {
            var market = new Market()
            {
                Location = location
            };

            await this.marketRepository.AddAsync(market);
            await this.marketRepository.SaveChangesAsync();

            return market.Id;
        }

        public int GetCount()
        {
            return this.marketRepository.All().Count();
        }

        public IEnumerable<MarketViewModel> GetAll() => this.marketRepository.All().To<MarketViewModel>();
    }
}
