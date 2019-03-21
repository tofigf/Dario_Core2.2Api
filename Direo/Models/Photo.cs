using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class Photo
    {
       
        public int Id { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime DateAdded { get; set; }

        public bool IsMain { get; set; }

        public int ListingId { get; set; }
        public virtual Listing Listing { get; set; }
    }
}
