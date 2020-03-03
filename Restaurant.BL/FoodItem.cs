using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        [ForeignKey("Category_FK")]
        public int CategoryId { get; set; }
    }
}