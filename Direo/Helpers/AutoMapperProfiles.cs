using AutoMapper;
using Direo.Dtos;
using Direo.Dtos.CategoryDtos;
using Direo.Dtos.MainDtos;
using Direo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //User
            CreateMap<UserForRegisterDto, User>().ReverseMap();
            CreateMap<UserForUpdateDto, User>().ReverseMap();
            CreateMap<User, UserForListDto>().ReverseMap();
            CreateMap<User, UserForDetailDto>().ReverseMap();
      
            ///Main
            //Category
            CreateMap<CategoryDtos, CategoryDto>().ReverseMap();
            //Location
            CreateMap<Location, LocationDto>().ReverseMap();
            //Listing
            CreateMap<ListingPostDto, Listing>().ReverseMap();


        }
      
    }
}
