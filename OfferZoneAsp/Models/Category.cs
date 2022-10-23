using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfferZoneAsp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}