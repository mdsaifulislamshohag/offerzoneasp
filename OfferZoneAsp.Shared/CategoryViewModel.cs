using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OfferZoneAsp.Shared
{
    public class CategoryViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
