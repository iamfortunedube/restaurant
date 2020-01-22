using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.BL
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required, StringLength(255)]
        public string CategoryName { get; set; }

        public byte[] CategoryImage { get; set; }

        [Required, StringLength(255)]
        public string SellingTime { get; set; }
    }
}
