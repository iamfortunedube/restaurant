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
    public class MenuItemsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Category Category { get; set; }

        public MenuItemsModel(IRestaurantData restaurantData)
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
    }
}