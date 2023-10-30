using Microsoft.AspNetCore.Mvc;
using OQPATE.API.Services;
using OQPATE.DB.Models;

namespace OQPATE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationServices _authorizationService;
        public AuthController(IAuthorizationServices authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthorizationRequest authorization)
        {
            var result = await _authorizationService.GetAuthorizationResponseAsync(authorization);

            if(result != null)
                return Ok(result);

            return Unauthorized();
        }


    }
}
