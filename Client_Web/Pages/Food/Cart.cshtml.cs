using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.BL;

namespace Client_Web.Pages.Food
{
    public class CartModel : PageModel
    {
        public List<ShoppingCart> cart { get; set; }
        public double Total { get; set; }
    }
}