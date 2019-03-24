using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class OpeningHour
    {
        public int Id { get; set; }

     
        public int ListingId { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan CloseTime { get; set; }

        public bool IsClosed { get; set; }

        //////////////////////////////////////////
        public virtual Listing Listing { get; set; }

    }
}
