using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.BL
{
    public class ShoppingCart
    {

        public int Id { get; set; }
        public FoodItem FoodItem { get; set; }
        public int Quantity { get; set; }
    }
}
