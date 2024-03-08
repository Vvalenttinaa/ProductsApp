using MyApp.Models.DTOs;
using MyApp.Models.Requests;

namespace MyApp.Services
{
    public interface TypeService
    {
        Task<List<TypeDto>> GetAll();
        Task<TypeDto> AddType(TypeRequest request);
        Task<TypeDto> GetType(int id);
        Task<int?> FindIdByName(string name);
        Task<bool> Exist(string name);
    }
}
