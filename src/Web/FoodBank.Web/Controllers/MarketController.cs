using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodBank.Data.Common;
using FoodBank.Data.Models;
using FoodBank.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodBank.Web.Controllers
{
    public class MarketController : BaseController
    {
        private readonly IRepository<Market> marketRepository;

        public MarketController(IRepository<Market> marketRepository)
        {
            this.marketRepository = marketRepository;
        }

        public IActionResult ShopNow()
        { 
            return View();
        }

        public IActionResult Discounts()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            var markets = this.marketRepository.All().Select(
                x => new IndexMarketViewModel
                {
                    Location = x.Location
                });

            var viewModel = new IndexViewModel
            {
                Markets = markets
            };

            return this.View(viewModel);
        }
    }
}
