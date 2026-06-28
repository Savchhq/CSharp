using Microsoft.AspNetCore.Identity;
using TodoApp.BLL.DTOs.Auth;
using TodoApp.BLL.Interfaces;
using TodoApp.Core.Interfaces;
using TodoApp.Core.Models;

namespace TodoApp.BLL.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenRepository _tokenRepository;

    public AuthService(UserManager<AppUser> userManager, ITokenRepository tokenRepository)
    {
        _userManager = userManager;
        _tokenRepository = tokenRepository;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterRequestDto requestDto)
    {
        var user = new AppUser
        {
            UserName = requestDto.Email,
            Email = requestDto.Email
        };

        return await _userManager.CreateAsync(user, requestDto.Password);
    }

    public async Task<string?> LoginAsync(LoginRequestDto requestDto)
    {
        var user = await _userManager.FindByEmailAsync(requestDto.Email);

        if (user != null)
        {
            var checkPasswordResult = await _userManager.CheckPasswordAsync(user, requestDto.Password);

            if (checkPasswordResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                return _tokenRepository.CreateJWTToken(user, roles.ToList());
            }
        }

        return null;
    }
}