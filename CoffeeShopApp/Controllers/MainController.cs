using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CoffeeShopApp.Models;


namespace CoffeeShopApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            ViewBag.ProductList = GetProductList();
            return View();
        }
        public ActionResult admin()
        {
            ViewBag.ProductList = GetProductList();
            return View();

        }
        public ActionResult addproduct()
        {
            return View();
        }
        public ActionResult InsertProduct(Product p)
        {
            CoffeeShopDBEntities dbContext = new CoffeeShopDBEntities();
            dbContext.Products.Add(p);
            dbContext.SaveChanges();
            ViewBag.ProductList = GetProductList();
            return View("admin");
        }
        public ActionResult delete(string Product)
        {
            CoffeeShopDBEntities dbContext = new CoffeeShopDBEntities();
            Product toDelete = dbContext.Products.Find(Product);
            dbContext.Products.Remove(toDelete);
            dbContext.SaveChanges();//save changes to DB
            ViewBag.ProductList = GetProductList();
            return View("admin");
        }
        private static List<Product> GetProductList()
        {
            CoffeeShopDBEntities dbContext = new CoffeeShopDBEntities();

            List<Product> productList = dbContext.Products.ToList();
            return productList;
        }

        public ActionResult ProcessSignUp(UserData data)
        {
            ViewBag.Message = "Thanks " + data.Uname+"("+data.Email+")";
           
            return View("Index",data);
            //return Redirect("https://www.google.com"); 

        }

        public ActionResult Order(string product)
        {
            ViewBag.ProductList = GetProductList();

            if (Session["shoppingCart"] == null)
            {
                Dictionary<string, Product> tempSC = new
                    Dictionary<string, Product>();

                Session["shoppingCart"] = tempSC; 
            }

            Dictionary<string, Product> shoppingCart = 
                (Dictionary<string, Product>)Session["shoppingCart"];


            if (!shoppingCart.ContainsKey(product))//first time adding the product
            {
                shoppingCart.Add(product, new Product(product, 1, 1));

            }

            else
            {
                shoppingCart[product].Quantity += 1;
            }

            ViewBag.ShoppingCart=shoppingCart.Values.ToList();

            return View("Index");
        }
    }
}