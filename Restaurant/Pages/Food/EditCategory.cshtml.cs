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
    public class EditCategoryModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [BindProperty]
        public Category Category { get; set; }
        public EditCategoryModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                Category = restaurantData.GetById(categoryId.Value);
            }
            else
            {
                Category = new Category();
            }
            if (Category == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Category.Id > 0)
            {
                restaurantData.UpdateCategory(Category);
            }
            else
            {
                restaurantData.AddCategory(Category);
            }
            restaurantData.Commit();
            return RedirectToPage("./MenuItems", new { categoryId = Category.Id });
        }
    }
}