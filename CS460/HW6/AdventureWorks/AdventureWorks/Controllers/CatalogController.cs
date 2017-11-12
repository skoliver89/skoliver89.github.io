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

        // GET: Catalog/Product?id=<product id>
        //Display the details of a product
        public ActionResult Product()
        {
            if (Request.QueryString["id"] == null)
            {
                return RedirectToAction("Index");
            }

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

            //Get the product image
            byte[] image = product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
            //Give the product image to the View
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);

            return View(product);
        }

        //GET : /Catalog/ProductReview?id=<product id>
        public ActionResult ProductReview()
        {
            string id = Request.QueryString["id"];
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            var product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();
            ViewBag.ProdID = id;
            ViewBag.prodName = product.Name;
            //Get the product image
            byte[] image = product.ProductProductPhotoes.FirstOrDefault().ProductPhoto.LargePhoto;
            //Give the product image to the View
            ViewBag.image = "data:image/png;base64," + Convert.ToBase64String(image, 0, image.Length);

            return View();
        }
        //POST : /Catalog/ProductReview?id=<product id>
        //Enter the new review into the DB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductReview([Bind(Include = "ProductReviewID, ProductID, ReviewerName, " +
            "ReviewDate, EmailAddress, Rating, Comments, CommentsModifiedDate, Product ")] ProductReview review)
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                //Set the values for the fields to be auto generated from the product/temporal stuff
                review.ProductID = Convert.ToInt32(id);
                review.ReviewDate = DateTime.Now;
                review.ModifiedDate = review.ReviewDate;
                review.Product = db.Products.Where(p => p.ProductID.ToString() == id).FirstOrDefault();

                //Add the new review to the DB and save
                db.ProductReviews.Add(review);
                db.SaveChanges();
                //after save redirect back to the product that was just reviewed
                return Redirect("/Catalog/Product?id="+id);
            }

            return View(review);
        }

    }
}