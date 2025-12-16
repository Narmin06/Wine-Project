using App.Business.Services.ExternalServices.Interfaces;
using App.Business.Validators.AuthValidators;
using App.Core.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO dto)
        {
            var validationResult = await new RegisterDTOValidator().ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var registerResponse = await _authService.RegisterAsync(dto);
            return Ok(registerResponse);
        }

        // Login Section
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO dto)
        {
            var loginResponse = await _authService.LoginAsync(dto);

            var token = loginResponse.Token;

            return Ok(new { message = "Login successful", token });
        }

        [HttpGet("check-authorize")]
        [Authorize]
        public IActionResult IsBearerAuthorizedAsync()
        {
            return Ok(new { message = "This is a protected method. You have authorized with bearer." });
        }

        [HttpPost("get-user-summary")]
        [Authorize]
        public async Task<IActionResult> GetProtectedDataAsync([FromBody] JwtRequestDTO dto)
        {
            if (string.IsNullOrEmpty(dto.jwtTokenString))
                return Unauthorized(new { message = "Token is missing or invalid" });

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(dto.jwtTokenString);

            var id = jwtToken.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

            var oldUser = await _authService.CheckUserNotFoundAsync(id);

            var data = new
            {
                message = "This is protected data",
                userId = id,
                role = role,
                username = oldUser.UserName,
                userEmail = oldUser.Email,
                fullName = oldUser.FullName,
                phoneNumber = oldUser.PhoneNumber,
                imageUrl = oldUser.ImageUrl,
            };

            return Ok(data);
        }
    }
}

