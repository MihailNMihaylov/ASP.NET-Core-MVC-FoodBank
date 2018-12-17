using AutoMapper;
using FoodBank.Data.Common;
using FoodBank.Data.Models;
using FoodBank.Services.DataServices;
using FoodBank.Web.Areas.Administration.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodBank.Web.Areas.Administration.Controllers
{
    public class MarketController : AdministrationBaseController
    {
        private readonly IMarketService marketService;
        private readonly IRepository<Market> markets;

        public MarketController(IMarketService marketService, IRepository<Market> markets)
        {
            this.marketService = marketService;
            this.markets = markets;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMarketViewModel model)
        {
            var market  = Mapper.Map<Market>(model);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(market.Location);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Black;
            await this.markets.AddAsync(market);
            await this.markets.SaveChangesAsync();

            return this.RedirectToAction("Index");
        }
    }
}