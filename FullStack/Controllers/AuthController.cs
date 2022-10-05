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

        public AuthController(IUserAccountsService userAccountsService)
        {
            _userAccountsService = userAccountsService;
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
    }
}
