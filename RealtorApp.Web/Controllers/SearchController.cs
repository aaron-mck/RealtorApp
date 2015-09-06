using RealtorApp.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtorApp.Web.Controllers
{
    public class SearchController : Controller
    {
        private RealtorMLSEntities db = new RealtorMLSEntities();

        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Search
        [HttpPost]
        public ActionResult Index(Listing listing)
        {
            List<string> whereClauses = new List<string>();

            if (listing.MLS > 0)
                whereClauses.Add(string.Format("MLS LIKE '%{0}%'", listing.MLS));

            if (!String.IsNullOrEmpty(listing.City))
                whereClauses.Add(string.Format("City LIKE '%{0}%'", listing.City));

            if (!String.IsNullOrEmpty(listing.State))
                whereClauses.Add(string.Format("State LIKE '%{0}%'", listing.State));

            if (listing.Zipcode > 0)
                whereClauses.Add(string.Format("Zipcode LIKE '%{0}%'", listing.Zipcode));

            if (listing.Bedrooms > 0)
                whereClauses.Add(string.Format("Bedrooms LIKE '%{0}%'", listing.Bedrooms));

            if (listing.Bathrooms > 0)
                whereClauses.Add(string.Format("Bathrooms LIKE '%{0}%'", listing.Bathrooms));

            if (listing.SquareFeet > 0)
                whereClauses.Add(string.Format("SquareFeet LIKE '%{0}%'", listing.SquareFeet));

            if (whereClauses.Count > 0)
            {
                string sql = "SELECT * FROM Listing";
                sql += " WHERE " + String.Join(" AND ", whereClauses);
                IEnumerable<Listing> listings = db.Listings.SqlQuery(sql);
                return View("Results", listings);
            }
            else
            {
                return View("Results", null);
            }


        }
    }
}