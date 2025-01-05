using Final.BL.DTOs.UserDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface IAppUserService
    {
        Task<bool> RegisterAppUserAsync(RegisterUserDto registerDto, IUrlHelper urlHelper);
        Task<string> LoginAppUserAsync(LoginUserDto loginDto);
        Task<bool> LogoutAppUserAsync();
        Task<bool> ConfirmEmailAsync(string userId, string token);
        List<AppUserReadDto> GetAllUsers();
        Task<AppUserReadDto> GetOneUser(string userId);
    }
}
