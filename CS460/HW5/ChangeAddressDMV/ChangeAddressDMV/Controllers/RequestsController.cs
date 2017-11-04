using ChangeAddressDMV.DAL;
using ChangeAddressDMV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeAddressDMV.Controllers
{
    public class RequestsController : Controller
    {
        //db variable
        private hw5dbContext db = new hw5dbContext();

        // GET: Requests
        // Listing all current requests in the index
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        // GET: Requests/New (Create)
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        // POST: Requests/New (Create)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Include = "RequestID, IDNumber, DOB, FullName, NewResAddr, " +
            "NewResCityStateZip, NewResCounty, NewMailAddr, NewMailCityStateZip, NewMailCounty")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }

}