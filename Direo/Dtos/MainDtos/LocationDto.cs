using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Dtos.MainDtos
{
    public class LocationDto
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
