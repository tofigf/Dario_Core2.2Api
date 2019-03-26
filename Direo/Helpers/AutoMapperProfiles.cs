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
            CreateMap<ListingPostDto, Listing>().ReverseMap()
                .ForMember(dto=>dto.TagsGets,opt=> opt
                .MapFrom(src=>src.ListingTags
                .Select(s=>s.Tag)
                .ToList()));
            CreateMap<Listing, ListingGetDto>().ForMember(dto=>dto.PhotoFileName,opt=>opt
            .MapFrom(src=> $"{appBaseUrl}/Uploads/" + src.PhotoFileName))
            .ForMember(dto => dto.TagsGets, opt => opt
                   .MapFrom(src => src.ListingTags
                   .Select(s => s.Tag)
                   .ToList()));
            //ListingPhotos
            CreateMap<PhotosPostDto, Photo>()
      .ForMember(dto => dto.PhotoUrl, opt => opt.MapFrom(src => src.PhotoUrl))
      .ForMember(dto => dto.PhotoName, opt => opt.MapFrom(src => src.PhotoName));
          
            //GetListig
            CreateMap<Photo, PhotosGetDto>()
    .ForMember(dto =>dto.PhotoName, opt => opt.MapFrom(src => $"{appBaseUrl}/Uploads/" + src.PhotoName));

            //Tags
            CreateMap<TagsPostDto, Tag>().ReverseMap()
                .ForMember(dto=>dto.ListingGetDto,opt=>opt
                .MapFrom(src=>src.Listings.Select(s=>s.Listing).ToList()));
     
            CreateMap<Tag, TagsGetDto>().ForMember(dto=>dto.ListingGetDto,opt=>
            opt.MapFrom(src=>src
            .Listings.Select(s=>s.Listing).ToList()));


            //Eger limit vermek isteyirkese bu methoddan istifade edeceyik
            //.MaxDepth(1)
        }
    }
}
