using FoodBank.Web.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodBank.Data.Models
{
    public class Order
    {
        public int FoodBankUserId { get; set; }
        public FoodBankUser FoodBankUser { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
