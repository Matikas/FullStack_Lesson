using FullStack.BL;
using FullStack.Domain;
using FullStack.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserAccountsService _userAccountsService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserAccountsService userAccountsService, IJwtService jwtService)
        {
            _userAccountsService = userAccountsService;
            _jwtService = jwtService;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            var domainContactDetails = signupDto.ContactDetails.Select(c => new ContactDetail
            {
                ContactValue = c.ContactValue,
                Type = c.Type
            }).ToList();

            var success = await _userAccountsService.CreateUserAccountAsync(signupDto.UserName, signupDto.Password, domainContactDetails);

            return success ? Ok() : BadRequest(new { ErrorMessage = "User already exist" });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var (loginSuccess, account) = await _userAccountsService.LoginAsync(loginDto.UserName, loginDto.Password);

            if (loginSuccess)
            {
                return Ok(new { Token = _jwtService.GetJwtToken(account) });
            }
            else
            {
                return BadRequest(new { ErrorMessage = "Login failed" });
            }
        }
    }
}
