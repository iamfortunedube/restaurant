using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.BL
{
    public class ShoppingCart
    {
        [Key]
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int FoodItemId { get; set; }
        public  virtual FoodItem FoodItem { get; set; }
    }
}
