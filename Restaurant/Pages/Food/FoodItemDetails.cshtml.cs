using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.BL;
using Restaurant.Data;

namespace Restaurant.Pages.Food
{
    public class FoodItemDetailsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public FoodItem FoodItem { get; set; }

        public FoodItemDetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int foodItemId)
        {
            FoodItem = restaurantData.GetFoodItemById(foodItemId);
            if (FoodItem == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}