using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorApp.DomainModel;

namespace RealtorApp.Web.Controllers
{
    public class ListingsController : Controller
    {
        private RealtorMLSEntities db = new RealtorMLSEntities();

        // GET: Listings
        public ActionResult Index()
        {
            return View(db.Listings.ToList());
        }

        // GET: Listings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MLS,Street1,Street2,City,State,Zipcode,Neighborhood,SalesPrice,DateListed,Bedrooms,Photos,Bathrooms,GarageSize,SquareFeet,LotSize,Description,ListingID")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listing);
        }

        // GET: Listings/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MLS,Street1,Street2,City,State,Zipcode,Neighborhood,SalesPrice,DateListed,Bedrooms,Photos,Bathrooms,GarageSize,SquareFeet,LotSize,Description,ListingID")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        // GET: Listings/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Listings/{id}/Images
        [HttpGet]
        public ActionResult Images(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View("Images", listing);
        }

        // POST: Listings/{id}/UploadImages
        [HttpPost]
        public ActionResult UploadImages(int id, IEnumerable<HttpPostedFileBase> files)
        {
            Listing listing = db.Listings.Find(id);
            if (listing == null)
            {
                return HttpNotFound();
            }

            string listingDir = Server.MapPath(string.Format("~/ListingImages/{0}/", id));

            if (!Directory.Exists(listingDir))
            {
                Directory.CreateDirectory(listingDir);
            }
            foreach (var file in files)
            {
                // Add validation to not save changes if files are null
                if (file != null)
                {
                    file.SaveAs(string.Format("{0}/{1}", listingDir, file.FileName));
                    if (listing.ListingImages.All(i => i.ImageName.ToLower() != file.FileName.ToLower()))
                    {
                        listing.ListingImages.Add(new ListingImage{ImageName = file.FileName});
                    }                    
                }
            }
            db.SaveChanges();
            return RedirectToAction("Images");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
