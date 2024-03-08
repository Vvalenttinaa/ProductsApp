using MyApp.Models.DTOs;
using MyApp.Models.Requests;

namespace MyApp.Services
{
    public interface AttributeNameService
    {
        Task<List<AttributeNameDto>> GetAll();
        Task<AttributeNameDto> AddAttributeName(AttributeNameRequest request);
        Task<AttributeNameDto> GetAttributeName(int id);

    }
}
