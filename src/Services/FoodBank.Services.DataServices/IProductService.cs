using FoodBank.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Services.DataServices
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAll();

        int GetCount();

        Task<int> Create(string name, decimal price);
    }
}
