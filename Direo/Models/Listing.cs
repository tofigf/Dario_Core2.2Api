﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public enum PriceRange
    {
        Ultra,
        Expensive,
        Moderate,
        Cheap
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Listing
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string LongDescription { get; set; }

        [MaxLength(100)]
        public string Tagline { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public PriceRange? PriceRangeId { get; set; }

        public Gender? Gender { get; set; }

        [MaxLength(200)]
        public string ShortDescription { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Website { get; set; }

        [MaxLength(50)]
        public string Facebook { get; set; }

        [MaxLength(50)]
        public string Twitter { get; set; }

        [MaxLength(50)]
        public string Google { get; set; }

        [MaxLength(50)]
        public string Linkedin { get; set; }

        [MaxLength(50)]
        public string Youtube { get; set; }

     
        public string Photo { get; set; }

        [MaxLength(100)]
        public string PhotoFileName { get; set; }


        [MaxLength(50)]
        public string VideoUrl { get; set; }

        public bool? IsSevenTwentyFour { get; set; }

        [MaxLength(100)]
        public string Longitude { get; set; }

        [MaxLength(100)]
        public string Latitude { get; set; }

        public int? ViewsCount { get; set; }

        public decimal? Rating { get; set; }

        public DateTime PostDate { get; set; }

        public bool Status { get; set; }


        public int CategoryId { get; set; }

        public int LocationId { get; set; }

        public int UserId { get; set; }

        public virtual CategoryDtos Category { get; set; }
        public virtual Location Location { get; set; }
        public virtual User User { get; set; }


        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<ReviewsListing> ReviewsListings { get; set; }
        public virtual ICollection<ListingTag>ListingTags { get; set; }
        public virtual ICollection<OpeningHour> OpeningHours { get; set; }
        public virtual ICollection<FagListing> FagListings { get; set; }

        public Listing()
        {
            ListingTags = new Collection<ListingTag>();
        }
    }
}
