using Microsoft.AspNetCore.Mvc;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;
using System.Security.Claims;

namespace MyApp.Services
{
    public interface AttributeService
    {
        Task<List<AttributeDto>> GetAll();
        Task<AttributeDto> GetAttribute(int id);
        Task<AttributeDto> AddAttribute(AttributeRequest request);
    }
}
