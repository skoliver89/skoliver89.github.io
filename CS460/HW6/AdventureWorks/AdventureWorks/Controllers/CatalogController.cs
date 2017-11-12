using AdventureWorks.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.Controllers
{
    public class CatalogController : Controller
    {
        //interface to the DB/models
        AdventureWorks2014Context db = new AdventureWorks2014Context();

        // GET: Catalog
        public ActionResult Index()
        {
            return View(db.ProductSubcategories);
        }

        // GET: Catalog/Accessories
        public ActionResult Accessories()
        {
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Accessories").Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            return View();
        }
        // POST: Catalog/Accessories
        [HttpPost]
        public ActionResult Accessories(string subCat)
        {
            //Maintain the Bike Catalog buttons
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Accessories").Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            //find the products in the sub category
            var products = db.Products.Where(s => s.ProductSubcategory.Name == subCat
                                                    && s.FinishedGoodsFlag == true
                                                    && s.DiscontinuedDate == null
                                                    && s.SellEndDate == null);
            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Accessories");
        }

        // GET: Catalog/Bikes
        public ActionResult Bikes()
        {
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Bikes").Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            var products = db.Products;
            return View(products);
        }
        // POST: Catalog/Bikes
        [HttpPost]
        public ActionResult Bikes(string subCat)
        {
            //Maintain the Bike Catalog buttons
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Bikes").Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            //find the products in the sub category
            var products = db.Products.Where(s => s.ProductSubcategory.Name == subCat
                                                    && s.FinishedGoodsFlag == true
                                                    && s.DiscontinuedDate == null
                                                    && s.SellEndDate == null);

            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Bikes");
        }
    
        // GET: Catalog/Components
        public ActionResult Components()
        {
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Components").Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            return View();
        }
        // POST: Catalog/Components
        [HttpPost]
        public ActionResult Components(string subCat)
        {
            //Maintain the Bike Catalog buttons
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Components").Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            //find the products in the sub category
            var products = db.Products.Where(s => s.ProductSubcategory.Name == subCat
                                                    && s.FinishedGoodsFlag == true
                                                    && s.DiscontinuedDate == null
                                                    && s.SellEndDate == null);
            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Components");
        }
        // GET: Catalog/Clothing
        public ActionResult Clothing()
        {
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Clothing" && n.Products.Count() > 0).Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            return View();
        }
        // POST: Catalog/Clothing
        [HttpPost]
        public ActionResult Clothing(string subCat)
        {
            //Maintain the Bike Catalog buttons
            List<string> subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Clothing" && n.Products.Count() > 0).Select(sn => sn.Name).ToList();
            ViewBag.subCats = subCats;

            //find the products in the sub category
            var products = db.Products.Where(s => s.ProductSubcategory.Name == subCat
                                                    && s.FinishedGoodsFlag == true
                                                    && s.DiscontinuedDate == null
                                                    && s.SellEndDate == null);
            if (products.Count() > 0)
            {
                return View(products);
            }
            return RedirectToAction("Clothing");
        }

        // GET: Catalog/Product?id=<id>
        //Display the details of a product
        public ActionResult Product()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            var product = db.Products.Where(p => p.ProductID == id).FirstOrDefault();
            //Get the product Model ID for the Description.
            int? pmi = product.ProductModelID;
            //Get the english description
            string desc = "Not Availiable";
            if (pmi != null) //if there is a Product Model ID load in the description
            {
                desc = db.ProductModelProductDescriptionCultures.Where(p => p.ProductModelID == pmi).FirstOrDefault().ProductDescription.Description;
            }
            ViewBag.desc = desc;

            return View(product);
        }
    }
}