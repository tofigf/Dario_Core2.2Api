using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Dtos.MainDtos
{
    public class TagsPostDto
    {
        public int Id { get; set; }

        public IEnumerable<ListingGetDto> ListingGetDto { get; set; }

        public TagsPostDto()
        {
            ListingGetDto = new Collection<ListingGetDto>();
        }

    }
}
