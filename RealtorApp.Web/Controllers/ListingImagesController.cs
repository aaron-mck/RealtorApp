using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealtorApp.DomainModel;

namespace RealtorApp.Web.Controllers
{
    public class ListingImagesController : Controller
    {
        private RealtorMLSEntities db = new RealtorMLSEntities();

        // GET: ListingImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListingImage listingImage = db.ListingImages.Find(id);
            if (listingImage == null)
            {
                return HttpNotFound();
            }
            return View(listingImage);
        }

        // POST: ListingImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int listingId)
        {
            ListingImage listingImage = db.ListingImages.Find(id);
            db.ListingImages.Remove(listingImage);
            System.IO.File.Delete(Server.MapPath(String.Format("~/ListingImages/{0}/{1}", listingId, listingImage.ImageName)));
            db.SaveChanges();
            return RedirectToAction("Images", "Listings", new { id = listingId });
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
