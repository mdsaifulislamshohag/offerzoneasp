using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OfferZoneAsp.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string DiscountedPrice { get; set; }
        public string Location { get; set; }
        public string OfferImageName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string FbLink { get; set; }
        public string InstagramLink { get; set; }
        public string TwitterLink { get; set; }
        public string WebsiteLink { get; set; }
        public string ContactNumber { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public int OfferTypeId { get; set; }


    }
}