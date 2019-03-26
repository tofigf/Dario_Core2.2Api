using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Dtos.MainDtos
{
    public class PhotosPostDto
    {

        public string PhotoUrl { get; set; }

        [MaxLength(100)]
        public string PhotoName { get; set; }
    }
}
