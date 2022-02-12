using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMobileStore.Models
{
    public class Product
    {
        public Product()
        {
            this.Orders = new List<Order>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public Nullable<double> price { get; set; }
        public Nullable<int> quatity { get; set; }
        public string Photo { get; set; }
        public string description { get; set; }
        public Nullable<int> IdCat { get; set; }
        public string color { get; set; }
        public Nullable<double> storage { get; set; }
        public Nullable<int> score { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}