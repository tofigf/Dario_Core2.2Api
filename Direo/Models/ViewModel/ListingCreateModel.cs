using Direo.Dtos.MainDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models.ViewModel
{
    public class ListingCreateModel
    {

        public ListingGetDto ListingGet { get; set; }
        public IEnumerable<PhotosGetDto> PhotosGet { get; set; }
        public IEnumerable<TagsGetDto> TagsGet { get; set; }

    }
}
