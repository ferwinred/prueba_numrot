using System;
using apiDotnet.models;
using apiDotnet.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace apiDotnet.controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService){
            _logger=logger;
            _userService=userService;
        }


        [HttpGet]
        public async Task<List<User>> FindAll()
        {
            return await _userService.FindUsers();
        }

        [HttpGet("maxAge")]
        public User? FindMaxAge()
        {
            return _userService.FindMaxAge();
        }

        [HttpGet("average")]
        public async Task<Average> AverageAge()
        {
            return await _userService.AverageAge();
        }

        [HttpGet("genre/{genre}", Name="GetUser")]
        public Genre Find(string genre)
        {
            return _userService.CountGenre(genre);
        }

        [HttpPost]
         public async Task<OkResult> Create(User body)
        {

            await _userService.CreateUser(body);

            return Ok();
          
        }

    }



}