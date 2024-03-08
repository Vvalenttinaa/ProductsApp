using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;

namespace MyApp.Services
{
    
    public interface AuthService
    {
        Task<UserDto> Register(RegisterRequest registerRequest);
        Task<string> Login(LoginRequest loginRequest);
        Task<UserDto> GetUser(int id);
    }
}
