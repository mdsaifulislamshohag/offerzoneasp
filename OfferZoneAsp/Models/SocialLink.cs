using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OfferZoneAsp.Models
{
    public class SocialLink
    {
        [Key]
        public int SocialLinkId { get; set; }
        public string Link { get; set; }
        public string Platform { get; set; }

    }
}
