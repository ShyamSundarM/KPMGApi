using Azure.Core;
using KPMGApi.Models;
using KPMGAssessmentAPI.Models;
using KPMGAssessmentAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KPMGApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;
        public AuthController( UserManager<IdentityUser> userManager, JwtService jwtService)
        {

            _userManager = userManager;
            _jwtService = jwtService;
        }

        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Login([FromBody] LoginCredential cred)
        //{
        //    var user = await _userManager.FindByEmailAsync(cred.Email);
        //    if (user == null)
        //    {
        //        return BadRequest("Bad credentials");
        //    }

        //    var isPasswordValid = await _userManager.CheckPasswordAsync(user, cred.Password);

        //    if (!isPasswordValid)
        //    {
        //        return BadRequest("Bad credentials");
        //    }

        //    return Ok();
        //}

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] LoginCredential cred)
        {
            var user = new IdentityUser { Email = cred.Email, UserName = cred.Email };
            var result = await _userManager.CreateAsync(user, cred.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            return StatusCode(500, result.Errors);
        }


        [HttpPost("BearerToken")]

        public async Task<ActionResult<AuthenticationResponse>> CreateToken(LoginCredential cred)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse { ErrorMessage = "Wrong Credentials"});
            }
            var user = await _userManager.FindByEmailAsync(cred.Email);
            if (user == null)
            {
                return BadRequest(new ErrorResponse { ErrorMessage = "Wrong Credentials" });
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, cred.Password);

            if (!isPasswordValid)
            {
                return BadRequest(new ErrorResponse { ErrorMessage = "Wrong Credentials" });
            }
            var token = _jwtService.CreateToken(user);
            return Ok(token);

        }
    }
}
