using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodBank.Data.Common;
using FoodBank.Data.Models;
using FoodBank.Services.Mapping;
using FoodBank.Services.ViewModels;

namespace FoodBank.Services.DataServices
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<int> Create(string name, decimal price)
        {
            var product = new Product()
            {
                Name = name,
                Price = price
            };

            await this.productRepository.AddAsync(product);
            await this.productRepository.SaveChangesAsync();

            return product.Id;
        }

        public IEnumerable<ProductViewModel> GetAll() => this.productRepository.All().To<ProductViewModel>();


        public int GetCount()
        {
            return this.productRepository.All().Count();
        }
    }
}
