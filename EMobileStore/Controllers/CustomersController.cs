using EMobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EMobileStore.Controllers
{
    public class CustomersController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var customer = db.Customers.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).FirstOrDefault();
            if (customer == null)
            {
                Session["login"] = "invalid email or password";
                return View();
            }
            else
            {
                Session["login"] = customer.Email;
                if (customer.Email.Equals("admin@admin.com"))
                {
                    Session["ad"] = customer.Email;
                }
                return RedirectToAction("index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(Customer c)
        {
            var isfound = db.Customers.Where(s => s.Email.Equals(c.Email)).FirstOrDefault();
            if (isfound == null)
            {
                Customer customer = new Customer();
                customer.Name = c.Name;
                customer.Email = c.Email;
                customer.Password = c.Password;
                customer.Phone = c.Phone;

                db.Customers.Add(c);
                db.SaveChanges();
                Session["reg"] = c.Email;
                return Login(customer.Email, customer.Password);
            }
            else
            {
                ViewBag.f = "The Email is Already Found";
                return View();
            }
        }

        public ActionResult Logout()
        {
            if (Session["ad"] != null)
            {
                Session["ad"] = null;
                FormsAuthentication.SignOut();
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();

            }
            else if (Session["login"] != null)
            {
                Session["login"] = null;
                FormsAuthentication.SignOut();
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();

            }

            return RedirectToAction("Login");

        }

    }
}