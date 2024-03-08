using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;
using System.Security.Claims;

namespace MyApp.Services.ServicesImpl
{
    public class AttributeServiceImpl : AttributeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AttributeServiceImpl(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<ActionResult> DeleteAttribute(Guid id, ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AttributeDto>> GetAll()
        {
            return _mapper.Map<List<AttributeDto>>(await _dbContext.Attribute.
               Include(a => a.AttributeName).
               ToListAsync());
        }

        public async Task<AttributeDto> AddAttribute(AttributeRequest attributeRequest)
        {
            
            var attribute = _mapper.Map<Models.Entities.Attribute>(attributeRequest);
            await _dbContext.Attribute.AddAsync(attribute);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AttributeDto>(attribute);
        }

        public async Task<AttributeDto> GetAttribute(int id)
        {
            return (await _dbContext.AttributeName.FindAsync(id)) is var attribute ?
                _mapper.Map<AttributeDto>(attribute) :
                null;
        }
    }
}
