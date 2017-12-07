using Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        FinalDBContext db = new FinalDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Items
        public ActionResult Items()
        {
            var items = db.Items.ToList();
            return View(items);
        }

        // GET: CreateItem
        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }

        // POST: CreateItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateItem([Bind(Include = "Name, Description, Seller")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Items");
            }
            
            return View(item);
        }

        //GET: ItemDetails
        public ActionResult ItemDetails(int id)
        {
            var item = db.Items.Where(i => i.ID == id).FirstOrDefault();
            return View(item);
        }

        //GET: EditItem
        [HttpGet]
        public ActionResult EditItem(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }

        //POST: EditItem
        //TODO FIX UPDATE DB ERROR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem([Bind(Include = "ID, Name, Description, Seller")] Item item)
        {
            if(ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Items");
            }
            return View(item);
        }

        //GET: DeleteItem
        public ActionResult DeleteItem(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }

        //POST: DeleteItem
        [HttpPost, ActionName("DeleteItem")]
        public ActionResult DeleteItemConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Items");
        }

        //GET: NewBid
        [HttpGet]
        public ActionResult NewBid()
        {
            return View();
        }

        //POST: NewBid
        public ActionResult NewBid([Bind(Include = "Item, Buyer, Price")] Bid bid)
        {
            if(ModelState.IsValid)
            {
                bid.Timestamp = DateTime.Now;
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bid);
        }

        public JsonResult Bids(int id)
        {
            var bids = db.Bids.Where(bid => bid.Item == id)
                              .Select(s => new { s.Buyer1.Name, s.Price, s.Timestamp })
                              .OrderByDescending(o => o.Price)
                              .Take(5) //artificially limit to top 5 bids to save page space.
                              .ToList();
            return Json(bids, JsonRequestBehavior.AllowGet);
        }
    }
}