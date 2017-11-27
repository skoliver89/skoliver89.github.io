using ArtVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtVault.Controllers
{
    public class HomeController : Controller
    {
        //Interface to DB
        ArtVaultContext db = new ArtVaultContext();
     
        // GET: ~/
        // GET: ~/Home
        // GET: ~/Home/Index
        public ActionResult Index()
        {
            return View();
        }

        //GET ~/Home/Artists
        public ActionResult Artists()
        {
            List<ArtVault.Models.Artist> artists = db.Artists.ToList();
            return View(artists);
        }

        //GET ~/Home/ArtWorks
        public ActionResult ArtWorks()
        {
            var works = db.ArtWorks.ToList();
            return View(works);
        }

        //GET ~/Home/Classifications
        public ActionResult Classifications()
        {
            var classifications = db.Genres.ToList();
            return View(classifications);
        }

        //GET ~/Home/CreateArtist
        [HttpGet]
        public ActionResult CreateArtist()
        {
            return View();
        }

        //POST ~/Home/CreateArtist
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "Name, BirthDate, BirthCity")] Artist artist)
        {
           if (ModelState.IsValid)
            {
                
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }
    }
}