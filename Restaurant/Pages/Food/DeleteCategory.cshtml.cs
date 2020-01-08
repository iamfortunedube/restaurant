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
    public class DeleteCategoryModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Category Category { get; set; }
        public DeleteCategoryModel(IRestaurantData restaurantData )
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int categoryId)
        {
            Category = restaurantData.GetById(categoryId);
            if (Category == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int categoryId)
        {
            var category = restaurantData.DeleteCategory(categoryId);
            restaurantData.Commit();

            if (category == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{category.CategoryName} deleted";
            return RedirectToPage("./Categories");
        }
    }
}