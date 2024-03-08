using AutoMapper;
using MyApp.Models.DTOs;
using MyApp.Models.Entities;
using MyApp.Models.Requests;
using MyApp.Services;
using Type = MyApp.Models.Entities.Type;

namespace MyApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Entities.Attribute, AttributeDto>(); 
            CreateMap<Product, ProductDto>();    
            CreateMap<Type,  TypeDto>();
            CreateMap<Unit, UnitDto>();
            CreateMap<User, UserDto>();
            CreateMap<Models.Entities.Attribute, AttributeDto>();
            CreateMap<Attributename, AttributeNameDto>();


            CreateMap<AttributeRequest, Models.Entities.Attribute>();
            CreateMap<AttributeNameRequest, Attributename>();
            CreateMap<TypeRequest, Models.Entities.Type>();
            CreateMap<UnitRequest, Unit>();
            CreateMap<ProductRequest, Product>();

            CreateMap<RegisterRequest, User>().ForMember(dest => dest.Password, opt => opt.Ignore());

        }
    }
}
