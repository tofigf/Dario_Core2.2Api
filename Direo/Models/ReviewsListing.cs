using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class ReviewsListing
    {
        public int Id { get; set; }

        public int? ListingId { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "tinyint")]
        public int Rating { get; set; }

        public string PhotoUrl { get; set; }

        public string Message { get; set; }

        ////////////////////////////////////////////
        public virtual Listing Listing { get; set; }
        public virtual User User { get; set; }
    }
}
