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
    public class CategoriesModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        public CategoriesModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Categories = restaurantData.GetCategoriesByName(SearchTerm);
        }
    }
}