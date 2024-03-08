using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;

namespace MyApp.Services.ServicesImpl
{
    public class TypeServiceImpl : TypeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TypeServiceImpl(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<TypeDto>> GetAll()
        {
            return _mapper.Map<List<TypeDto>>(await _dbContext. Type.
                ToListAsync());
        }

        public async Task<TypeDto> AddType(TypeRequest typeRequest)
        {
            var type = _mapper.Map<Models.Entities.Type>(typeRequest);
            await _dbContext.Type.AddAsync(type);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TypeDto>(type);
        }

        public async Task<TypeDto> GetType(int id)
        {
            return (await _dbContext.Type.FindAsync(id)) is var attribute ?
                _mapper.Map<TypeDto>(attribute) :
                null;
        }
        public async Task<int?> FindIdByName(string name)
        {
            var type = await _dbContext.Type.FirstOrDefaultAsync(u => u.Name == name);
            return type?.Id;
        }
        public async Task<bool> Exist(string name)
        {
            return await _dbContext.Type.AnyAsync(u => u.Name == name);
        }
    }
}
