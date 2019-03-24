using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class FagListing
    {
        public int Id { get; set; }

     
        public int ListingId { get; set; }

     
        public string Question { get; set; }

     
        public string Answer { get; set; }

        public Listing Listing { get; set; }
    }
}
