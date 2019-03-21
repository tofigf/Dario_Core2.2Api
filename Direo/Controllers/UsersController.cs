using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Direo.Data;
using Direo.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Direo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        //Butun userleri getirmek
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(userToReturn);
        }
        //tek useri getirmek
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);
            var userToReturn = _mapper.Map<UserForDetailDto>(user);
            return Ok(userToReturn);
        }

        //yenilemek
        [HttpPut()]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserForUpdateDto userForUpdateDto)
        {
            if (userForUpdateDto.Id != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
         
            var userFromRepo = await _repo.GetUser(userForUpdateDto.Id);
         
            if (!ModelState.IsValid)
                return BadRequest();

            if (userForUpdateDto.Password != userForUpdateDto.ConfirmPassword)
                return StatusCode(701);

            var userToUpdate = _mapper.Map(userForUpdateDto, userFromRepo);

            var createdUser = await _repo.UpdatePost(userToUpdate, userForUpdateDto.Password);

            var userToReturn = _mapper.Map<UserForDetailDto>(createdUser);

            return Ok(userToReturn);


        }
   


    }
}