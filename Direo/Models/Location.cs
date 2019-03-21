using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models
{
    public class Location
    {
      
        public int Id { get; set; }
      
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
