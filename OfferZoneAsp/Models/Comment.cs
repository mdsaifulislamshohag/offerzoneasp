using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferZoneAsp.Models
{
    public class Comment
    {
        public int CommentId{ get; set; }
        public int UserId{ get; set; }
        public int OfferId { get; set; }
        public string CommentText { get; set; }


    }
}
