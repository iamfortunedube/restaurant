using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.BL
{
    public class FoodItem
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string FoodItemName { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        public int Price { get; set; }

        public string GetCategory { get; set; }
    }
}
