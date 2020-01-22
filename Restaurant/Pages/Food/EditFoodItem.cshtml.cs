using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Restaurant.BL;
using Restaurant.Data;

namespace Restaurant.Pages.Food
{
    public class EditFoodItemModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly AppDbContext _dbContext;

        [BindProperty]
        public FoodItem FoodItem { get; set; }
        public EditFoodItemModel(IRestaurantData restaurantData, AppDbContext _dbContext)
        {
            this.restaurantData = restaurantData;
            this._dbContext = _dbContext;
        }

        public IEnumerable<Category> DisplayCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? foodItemId)
        {
            DisplayCategory = await _dbContext.Categories.ToListAsync();

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

        public IActionResult OnPostAsync(FoodItem foodItems)
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