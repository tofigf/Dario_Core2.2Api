using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Dtos.MainDtos
{
    public class TagsGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public IEnumerable<ListingGetDto> ListingGetDto { get; set; }

        //public TagsGetDto()
        //{
        //    ListingGetDto = new Collection<ListingGetDto>();
        //}

    }
}
