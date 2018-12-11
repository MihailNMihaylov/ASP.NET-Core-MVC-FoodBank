using FoodBank.Web.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodBank.Data.Models
{
    public class FeedBack
    {
        public int Id { get; set; }

        public int FoodBankUserId { get; set; }
        public FoodBankUser FoodBankUser { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
