using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMvc.Models
{
    public class Product
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public decimal Price { get; set; }


        public string ImageUrl { get; set; }


        public int SubCategoryId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
