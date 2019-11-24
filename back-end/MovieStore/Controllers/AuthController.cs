using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Authentication;
using MovieStore.DataTransfer.Objects;
using MovieStore.Services;

namespace MovieStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/token")]
        public IActionResult Token([FromBody] UserLoginDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userService.ValidateUserPassword(user))
                return Unauthorized();

            var identityDTO = _userService.GetUserIdentity(user.Username);

            if (identityDTO == null)
                return BadRequest("Cannot get identity for this user.");

            var identity = GetClaimsIdentity(identityDTO);

            string token = JWTManager.GenerateToken(identity);

            return Ok(token);
        }



        private ClaimsIdentity GetClaimsIdentity(UserIdentityDTO user)
        {
            var claims = new List<Claim>
            {
                // It's not very nice to have this much, but it would be convenient on frontend))
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role),
                new Claim("Id", user.Id.ToString()),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName)
            };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}