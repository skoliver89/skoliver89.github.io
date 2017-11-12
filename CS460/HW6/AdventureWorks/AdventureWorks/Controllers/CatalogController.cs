using AdventureWorks.Models;
using System;
using System.Collections.Generic;
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
            var subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Accessories");
            return View(subCats);
        }

        // GET: Catalog/Bikes
        public ActionResult Bikes()
        {
            var subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Bikes");
            return View(subCats);
        }

        // GET: Catalog/Components
        public ActionResult Components()
        {
            var subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Components");
            return View(subCats);
        }

        // GET: Catalog/Clothing
        public ActionResult Clothing()
        {
            var subCats = db.ProductSubcategories.Where(n => n.ProductCategory.Name == "Clothing");
            return View(subCats);
        }
    }
}