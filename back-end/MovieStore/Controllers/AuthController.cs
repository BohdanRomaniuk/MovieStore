using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_userService.ValidateUserPassword(user))
            {
                return Unauthorized();
            }

            var identityDTO = _userService.GetUserIdentity(user.Username);

            if (identityDTO == null)
            {
                return BadRequest("Cannot get identity for this user.");
            }

            var identity = GetClaimsIdentity(identityDTO);

            identityDTO.Token = JWTManager.GenerateToken(identity);

            return Ok(identityDTO);
        }

        /// <summary>
        /// Regsters user. Each user is registered in "user" role, admin
        /// can change it in future.
        /// </summary>
        /// <param name="user">DTO with username, password, firstname and lastname</param>
        /// <returns>id of the user stored in database in header and token in body</returns>
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegistrationDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_userService.Get(u => u.UserName == user.UserName).Any())
            {
                return BadRequest("User already exists.");
            }

            var registeredUser = _userService.CreateUser(user);

            if (registeredUser == null)
            {
                return BadRequest("User registration failure.");
            }

            var identity = GetClaimsIdentity(registeredUser);

            string token = JWTManager.GenerateToken(identity);

            return Created(registeredUser.Id.ToString(), token);
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