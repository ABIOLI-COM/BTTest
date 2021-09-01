using BTTest.Server.Cards;

using Microsoft.AspNetCore.Mvc;

namespace BTTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        public CardsController()
        {
        }

        [HttpGet]
        public IActionResult GetValue(string rep)
        {
            var handBuildResult = Hand.Build(rep);
            return handBuildResult.IsError()
                ? BadRequest(handBuildResult.ErrorMessage)
                : Ok(handBuildResult.Result.GetValue());
        }
    }
}
