using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Restaurant.BL
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string CategoryName { get; set; }

        [Required, StringLength(255)]
        public string SellingTime { get; set; }
    }
}
