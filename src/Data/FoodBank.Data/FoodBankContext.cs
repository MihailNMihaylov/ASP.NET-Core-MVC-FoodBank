using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodBank.Data.Models;
using FoodBank.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodBank.Web.Models
{
    public class FoodBankContext : IdentityDbContext<FoodBankUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        public FoodBankContext()
        {

        }
        public FoodBankContext(DbContextOptions<FoodBankContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order>(x =>
            {
                x.HasKey(z => new
                {
                    z.FoodBankUserId,
                    z.ProductId
                });
            });
        }
    }
}
