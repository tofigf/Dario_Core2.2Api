using AutoMapper;
using Direo.Dtos;
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

   
            }
      
    }
}
