using App.Core.DTOs.AuthDTOs;
using App.Core.Entities.Identity;

namespace App.Business.Services.ExternalServices.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> LoginAsync(LoginDTO dto);
        Task<RegisterResponseDTO> RegisterAsync(RegisterDTO dto);
        Task<User> CheckUserNotFoundAsync(string id);
    }
}
