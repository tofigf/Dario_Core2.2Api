using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<ListingTag> Listings { get; set; }

        public Tag()
        {
            Listings = new Collection<ListingTag>();
        }
    }
}
