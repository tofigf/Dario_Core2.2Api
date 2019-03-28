using AutoMapper;
using Direo.Data;
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
            //App Url
            var appBaseUrl = MyHttpContext.AppBaseUrl;

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
            CreateMap<Listing, ListingGetDto>()
                .ForMember(dto=>dto.PhotoFileName,opt=>opt
            .MapFrom(src=> $"{appBaseUrl}/Uploads/" + src.PhotoFileName))
            .ForMember(dto => dto.TagsGet, opt => opt
                   .MapFrom(src => src.ListingTags
                   .Select(s => s.Tag)));
      
            //ListingPhotos
            CreateMap<PhotosPostDto, Photo>()
      .ForMember(dto => dto.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl))
      .ForMember(dto => dto.PhotoName, opt => opt.MapFrom(src => src.PhotoName));
          
            //GetListig
            CreateMap<Photo, PhotosGetDto>()
    .ForMember(dto =>dto.PhotoName, opt => opt
    .MapFrom(src => $"{appBaseUrl}/Uploads/" + src.PhotoName));

            //Tags
            CreateMap<TagsPostDto, Tag>().ReverseMap();
     
            CreateMap<Tag, TagsGetDto>();


            //Eger limit vermek isteyirkese bu methoddan istifade edeceyik
            //.MaxDepth(1)
        }
    }
}
