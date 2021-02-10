using CardCost.Application.Interfaces;
using CardCost.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CardCost.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class AccessUserController : ControllerBase
    {
        #region Fields

        private IAccessUserService _userService;

        #endregion

        #region Constructor

        public AccessUserController(IAccessUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Post Methods

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromBody] AccessUserInput userParams)
        {
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
