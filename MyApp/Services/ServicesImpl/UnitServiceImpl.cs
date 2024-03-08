using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;

namespace MyApp.Services.ServicesImpl
{
    public class UnitServiceImpl : UnitService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnitServiceImpl(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<UnitDto>> GetAll()
        {
            return _mapper.Map<List<UnitDto>>(await _dbContext.Unit.
               ToListAsync());
        }

        public async Task<UnitDto> AddUnit(UnitRequest unitRequest)
        {
            var unit = _mapper.Map<Models.Entities.Unit>(unitRequest);
            await _dbContext.Unit.AddAsync(unit);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UnitDto>(unit);
        }

        public async Task<UnitDto> GetUnit(int id)
        {
            return (await _dbContext.Unit.FindAsync(id)) is var unit ?
                _mapper.Map<UnitDto>(unit) :
                null;
        }

        public async Task<int?> FindIdByName(string name)
        {
            var unit = await _dbContext.Unit.FirstOrDefaultAsync(u => u.Name == name);
            return unit?.Id;
        }
        public async Task<bool> Exist(string name)
        {
            return await _dbContext.Unit.AnyAsync(u => u.Name == name);
        }
    }
}
