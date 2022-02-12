using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMobileStore.Models
{
    public class Products
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Product> LastProduct(int n)
        {
            return db.Products.OrderByDescending(p => p.ProductId).Take(n).ToList();
        }
        public List<Product> RelatedProduct(Product product, int n)
        {
            return db.Products.
              Where(p => p.IdCat == product.IdCat && p.IdCat == product.IdCat && p.ProductId != product.ProductId).Take(n).ToList();
        }


        public Product find(int id)
        {
            return db.Products.Find(id);
        }


        public List<Product> fromup(int n)
        {
            return db.Products.OrderBy(p => p.ProductId).Take(n).ToList();
        }
        public List<Product> FindAll()
        {
            return db.Products.ToList();

        }


    }
}