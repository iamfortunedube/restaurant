using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Restaurant.BL;
using Restaurant.Data;

namespace Client_Web.Pages.Food
{
    public class FoodItemsModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public IEnumerable<FoodItem> FoodItems { get; set; }
        public int Id { get; set; }

        public FoodItemsModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int? categoryId)
        {
            FoodItems = restaurantData.GetFoodItemByCategory(categoryId);
            return Page();
        }
    }
}