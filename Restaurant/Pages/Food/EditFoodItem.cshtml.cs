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
    public class EditFoodItemModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [BindProperty]
        public FoodItem FoodItem { get; set; }
        public EditFoodItemModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int? foodItemId)
        {
            if (foodItemId.HasValue)
            {
                FoodItem = restaurantData.GetFoodItemById(foodItemId.Value);
            }
            else
            {
                FoodItem = new FoodItem();
            }
            if (FoodItem == null)
            {
                return RedirectToPage(".NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (FoodItem.Id > 0)
            {
                restaurantData.UpdateFoodItem(FoodItem);
            }
            else
            {
                restaurantData.AddFoodItem(FoodItem);
            }
            restaurantData.Commit();
            return RedirectToPage("./FoodItems", new { foodItemId = FoodItem.Id });
        }
    }
}