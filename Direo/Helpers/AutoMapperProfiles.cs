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
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForUpdateDto, User>();

            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailDto>();
            /////////////////////////////////////
            ///Main
            //Category
            CreateMap<Category, CategoryDto>();
            //Location
            CreateMap<Location, LocationDto>();


   
            }
      
    }
}
