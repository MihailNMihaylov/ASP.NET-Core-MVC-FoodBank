using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FoodBank.Data.Common;
using FoodBank.Data.Models;
using FoodBank.Services.DataServices;
using FoodBank.Web.Areas.Administration.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodBank.Web.Areas.Administration.Controllers
{
    public class ProductController : AdministrationBaseController
    {
        private readonly IProductService productService;
        private readonly IRepository<Product> products;

        public ProductController(IProductService productService, IRepository<Product> products)
        {
            this.productService = productService;
            this.products = products;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            var product = Mapper.Map<Product>(model);

            await this.products.AddAsync(product);
            await this.products.SaveChangesAsync();

            return this.RedirectToAction("Index");
        }
    }
}