using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMobileStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<double> Payment { get; set; }
        public string username { get; set; }
        public Nullable<int> Product_fk { get; set; }

        public virtual Product Product { get; set; }
    }
}