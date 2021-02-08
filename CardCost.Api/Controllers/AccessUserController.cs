using AutoMapper;
using CardCost.Application.Interfaces;
using CardCost.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardCost.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AccessUserController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private IAccessUserService _userService;

        #endregion

        #region Constructor

        public AccessUserController(IAccessUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        #endregion

        #region Post Methods

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromBody] AccessUserInput userParams)
        {
            if (userParams == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.GetUser(userParams);

            if (user == null)
                return BadRequest("Incorrect Username or Password.");
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] AccessUserInput userParams)
        {
            if (userParams == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userService.CreateUser(userParams);

            if (user ==null)
                return BadRequest("An error has occured.");
            return Ok("The user Created successfully");
        }

        #endregion
    }
}
