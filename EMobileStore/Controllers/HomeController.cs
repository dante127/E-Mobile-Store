using EMobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMobileStore.Controllers
{
    public class HomeController : Controller
    {
        Products products = new Products();
        public ActionResult Index()
        {
            ViewBag.pro = products.fromup(2);
            ViewBag.last = products.LastProduct(6).Where(s=>s.IdCat!=4).ToList();
            ViewBag.acc = db.Products.Where(s => s.IdCat == 4).Take(4);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    
        public ActionResult ProductList()
        {
            ViewBag.pall = products.FindAll();
            return View();
        }

        public ActionResult ProductSingle(int id)
        {
            ViewBag.productd = products.find(id);
            ViewBag.related = products.RelatedProduct(products.find(id), 3);


            return View();
        }


        private int isfound(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].prodcut.ProductId == id)
                {
                    return i;
                }

            }
            return -1;
        }
        public ActionResult Cart(int id = 0)
        {
            if (Session["login"] == null)
            {
                return RedirectToAction("Login", "Customers");
            }

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();

                cart.Add(new Item()
                {
                    prodcut = products.find(id),
                    quantitiy = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isfound(id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        prodcut = products.find(id),
                        quantitiy = 1
                    });
                }
                else
                {
                    cart[index].quantitiy++;
                }
                Session["cart"] = cart;
            }
            return View();
        }

        public ActionResult delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(id);
            Session["cart"] = cart;
            return View("cart");
        }
        ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Apple()
        {

            ViewBag.pall = db.Products.Where(a => a.IdCat == 1).ToList();
            return View("ProductList");
        }

        public ActionResult Sam()
        {
            ViewBag.pall = db.Products.Where(a => a.IdCat == 2).ToList();
            return View("ProductList");
        }

        public ActionResult Lowprice()
        {
            ViewBag.pall = db.Products.Where(s => s.price <= 800).ToList();
            return View("ProductList");

        }

        public ActionResult Hightprice()
        {
            ViewBag.pall = db.Products.Where(s => s.price > 800).ToList();
            return View("ProductList");

        }


        public ActionResult star(FormCollection fc)
        {
            string rate = fc["rate"];
            int id = Convert.ToInt32(fc["id"]);
            Session["rate"] = "Thanks For Rating";

            var pro = db.Products.Find(id);
            pro.score = Convert.ToInt32(rate);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult Haw()
        {
            ViewBag.pall = db.Products.Where(a => a.IdCat == 3).ToList();
            return View("ProductList");
        }

        public ActionResult Acc()
        {
            ViewBag.pall = db.Products.Where(a => a.IdCat == 4).ToList();
            return View("ProductList");
        }


        public ActionResult CheckForm()
        {

            return View();
        }
    }
}