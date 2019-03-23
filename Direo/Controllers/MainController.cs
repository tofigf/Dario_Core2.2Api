﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Direo.Data.Repository.Interface;
using Direo.Dtos.CategoryDtos;
using Direo.Dtos.MainDtos;
using Direo.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Direo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainRepository _repo;
        private readonly IMapper _mapper;

        public MainController(IMainRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        //Butun kateqoriyalari getirmek
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.GetCategories();

            var CategoryToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(CategoryToReturn);
        }

        //Butun olkeleri getirmek
        [HttpGet]
        [Route("locations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _repo.GetLocations();

            var LocationToReturn = _mapper.Map<IEnumerable<LocationDto>>(locations);
            return Ok(LocationToReturn);
        }

        //Butun listingleri getirmek
        [HttpGet]
        [Route("listings")]
        public async Task<IActionResult> GetListing([FromQuery]ListingParam listingParam)
        {
             var listings = await _repo.GetListing(listingParam);

            var ListingToReturn = _mapper.Map<IEnumerable<ListingDto>>(listings);

             Response.AddPagination(listings.CurrentPage, listings.PageSize,
               listings.TotalCount, listings.TotalPages);

            return Ok(ListingToReturn);
        }

    }
}