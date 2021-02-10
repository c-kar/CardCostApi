using CardCost.Application.Interfaces;
using CardCost.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CardCost.Api.Controllers
{
    [ApiController]
    [Route("payment-cards-cost")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CardCostController : ControllerBase
    {
        #region Fields

        private readonly ICardCostService _cardCostService;

        #endregion

        #region Constructor

        public CardCostController(ICardCostService cardCostService) => _cardCostService = cardCostService;

        #endregion

        #region PostMethod

        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> GetCardDetails([FromBody] CardCostInput request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cardData = await _cardCostService.GetCardData(request);

            if (cardData == null)
                return BadRequest("Please enter a valid card number.");
            return Ok(cardData);
        }

        #endregion
    }
}
