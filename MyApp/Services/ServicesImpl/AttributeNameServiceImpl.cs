using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;

namespace MyApp.Services.ServicesImpl
{
    public class AttributeNameServiceImpl : AttributeNameService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AttributeNameServiceImpl(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<AttributeNameDto>> GetAll()
        {
            return _mapper.Map<List<AttributeNameDto>>(await _dbContext.AttributeName
                .Include(attribute => attribute.Unit) 
                .ToListAsync());
        }

        public async Task<AttributeNameDto> AddAttributeName(AttributeNameRequest attributeNameRequest)
        {
            var attributeName = _mapper.Map<Models.Entities.Attributename>(attributeNameRequest);
            await _dbContext.AttributeName.AddAsync(attributeName);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AttributeNameDto>(attributeName);
        }

        public async Task<AttributeNameDto> GetAttributeName(int id)
        {
            return (await _dbContext.AttributeName.FindAsync(id)) is var attribute ?
                _mapper.Map<AttributeNameDto>(attribute) :
                null;
        }
    }
}
