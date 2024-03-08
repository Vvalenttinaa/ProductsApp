using MyApp.Models.DTOs;
using MyApp.Models.Requests;

namespace MyApp.Services
{
    public interface UnitService
    {
        Task<List<UnitDto>> GetAll();
        Task<UnitDto> AddUnit(UnitRequest request);
        Task<UnitDto> GetUnit(int id);
        Task<int?> FindIdByName(string name);
        Task<bool> Exist(string name);


    }
}
