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
    public class DeleteFoodItemModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public FoodItem FoodItem { get; set; }
        public DeleteFoodItemModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int foodItemId)
        {
            FoodItem = restaurantData.DeleteFoodItem(foodItemId);
            if (FoodItem == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int foodItemId)
        {
            var foodItem = restaurantData.DeleteFoodItem(foodItemId);
            restaurantData.Commit();

            if (foodItem == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{foodItem.FoodItemName} deleted";
            return RedirectToPage("./FoodItems");
        }
    }
}