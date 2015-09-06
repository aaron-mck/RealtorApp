using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtorApp.DomainModel
{
    [MetadataType(typeof(ListingMetadata))]
    public partial class Listing
    {
    }

    internal sealed class ListingMetadata
    {
        [Required]
        public int MLS { get; set; }

        [Required]
        [Display(Name = "Address 1")]
        public string Street1 { get; set; }

        [Display(Name = "Address 2")]
        public string Street2 { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip")]
        public int Zipcode { get; set; }

        [Required]
        [Display(Name = "Neighborhood")]
        public string Neighborhood { get; set; }

        [Required]
        [Display(Name = "Sales Price")]
        public decimal SalesPrice { get; set; }

        [Required]
        [Display(Name = "Listed Date")]
        public System.DateTime DateListed { get; set; }

        [Required]
        [Display(Name = "# of Bedrooms")]
        public int Bedrooms { get; set; }

        [Required]
        [Display(Name = "# of Bathrooms")]
        public double Bathrooms { get; set; }

        [Display(Name = "Garage Size")]
        public Nullable<double> GarageSize { get; set; }

        [Required]
        [Display(Name = "Square Footage")]
        public int SquareFeet { get; set; }

        [Display(Name = "Lot Size")]
        public string LotSize { get; set; }

        [Required]
        [Display(Name = "Full Description")]
        public string Description { get; set; }

        [Key]
        public int ListingID { get; set; }
    }
}
