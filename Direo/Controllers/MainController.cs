using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Direo.Data.Repository.Interface;
using Direo.Dtos.CategoryDtos;
using Direo.Dtos.MainDtos;
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

        //Butun kateqoriyalari getirmek
        [HttpGet]
        [Route("locations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _repo.GetLocations();

            var LocationToReturn = _mapper.Map<IEnumerable<LocationDto>>(locations);
            return Ok(LocationToReturn);
        }

    }
}