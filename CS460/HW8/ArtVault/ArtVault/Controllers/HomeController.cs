using ArtVault.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
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
            List<Genre> genres = db.Genres.ToList();
            return View(genres);
        }

        //GET ~/Home/Artists
        public ActionResult Artists()
        {
            List<Artist> artists = db.Artists.ToList();
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

        //GET ~/Home/ArtistDetails/{Artist Name}
        public ActionResult ArtistDetails(string id)
        {
            //Debug.WriteLine("ArtistName = " + id);
            Artist artist = db.Artists.Find(id);
            //Debug.WriteLine("artist.Name = " + artist.Name);
            return View(artist);
        }

        //GET ~/Home/EditArtist/{artist name}
        [HttpGet]
        public ActionResult EditArtist(string id)
        {
            Artist artist = db.Artists.Find(id);
            return View(artist);
        }

        //POST ~/Home/EditArtist/{artist name}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditArtist([Bind(Include = "Name, BirthDate, BirthCity")] Artist artist)
        {
            if(ModelState.IsValid)
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Artists");
            }
            return View(artist);
        }

        //GET ~/Home/DeleteArtist/{artist name}
        [HttpGet]
        public ActionResult DeleteArtist(string id)
        {
            Artist artist = db.Artists.Find(id);
            return View(artist);
        }

        //POST ~/Home/DeleteArtist/{artist name}
        [HttpPost, ActionName("DeleteArtist")]
        public ActionResult DeleteArtistConfirmed(string id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Artists");
        }


    }
}