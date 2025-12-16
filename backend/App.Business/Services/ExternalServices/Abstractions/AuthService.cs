using App.Business.Helpers;
using App.Business.Services.ExternalServices.Interfaces;
using App.Core.DTOs.AuthDTOs;
using App.Core.Entities.Identity;
using App.Core.Exceptions.Commons;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace App.Business.Services.ExternalServices.Abstractions
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(
            UserManager<User> userManager,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }


        public async Task<LoginResponseDTO> LoginAsync(LoginDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);

            if (user == null)
                user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);

            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                throw new UnauthorizedAccessException("Email or password is incorrect.");

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault() ?? "RoleError";

            var token = JwtGenerator.GenerateToken(user, role, _configuration);

            return new LoginResponseDTO
            {
                Token = token
            };
        }

        public async Task<RegisterResponseDTO> RegisterAsync(RegisterDTO dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("User with this email already exists.");

            var user = _mapper.Map<User>(dto);

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Registration failed: {errors}");
            }

            await _userManager.AddToRoleAsync(user, "User");

            var token = JwtGenerator.GenerateToken(user, "User", _configuration);

            return new RegisterResponseDTO
            {
                Message = "Registration successful",
                Token = token
            };
        }

        public async Task<User> CheckUserNotFoundAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                throw new EntityNotFoundException($"Entity of type {typeof(User).Name.ToLower()} not found.");

            return user;
        }
    }
}
