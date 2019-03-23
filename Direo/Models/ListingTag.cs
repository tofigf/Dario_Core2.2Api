using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class ListingTag
    {
        
        public int Id { get; set; }

  
        public int ListingId { get; set; }

     
        public int TagId { get; set; }

        public virtual Listing Listing { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
