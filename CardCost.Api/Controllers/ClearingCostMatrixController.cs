using CardCost.Application.Interfaces;
using CardCost.Core.Models.Base;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CardCost.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClearingCostMatrixController : ControllerBase
    {
        #region Fields

        private readonly ICCMatrixService _clearingCostService;

        #endregion

        #region Constructor
        
        public ClearingCostMatrixController(ICCMatrixService clearingCostService) => _clearingCostService = clearingCostService;

        #endregion

        #region GetMethods

        [HttpGet("get-all")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var ccMatrix = await _clearingCostService.GetAllClearingCosts();

            if (ccMatrix == null)
                return NoContent();
            return Ok(ccMatrix); 
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSingle(int id)
        {
            if (id == 0)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cCost = await _clearingCostService.GetClearingCost(id);
            if (cCost == null)
                return NotFound();
            return Ok(cCost);
        }

        #endregion

        #region PostMethods

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CreateClearingCost([FromBody] BaseModel request)
        {
            if (request == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newCost = await _clearingCostService.CreateClearingCost(request);
            if (newCost == null)
                return BadRequest();
            return Ok(newCost);
        }

        #endregion

        #region PutMethods

        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateClearingCost(int id, [FromBody] BaseModel request)
        {
            if (request == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _clearingCostService.UpdateClearingCost(id, request);
            return Ok("Clearing Cost updated successfully.");
        }

        #endregion

        #region DeleteMethods

        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clearingCostService.DeleteClearingCost(id);
            return Ok("Clearing Cost deleted successfully.");
        }

        #endregion
    }
}
