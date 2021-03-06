﻿using Direo.Dtos.MainDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Models.ViewModel
{
    public class ListingDtoCreateModel
    {
        public ListingPostDto ListingPost { get; set; }
        public IEnumerable<PhotosPostDto> PhotosPost { get; set; }
        public IEnumerable<TagsPostDto> TagsPost { get; set; }
    }
}
