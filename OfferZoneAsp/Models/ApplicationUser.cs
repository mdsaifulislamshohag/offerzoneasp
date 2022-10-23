using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OfferZoneAsp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string LogoImage { get; set; }
        public string UserType { get; set; }
        public string UserRole { get; set; }
    }
}