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
        private RequestContext db = new RequestContext();

        // GET: Requests
        // Listing all current requests in the index
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }
    }
}