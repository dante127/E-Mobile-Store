using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMobileStore.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}