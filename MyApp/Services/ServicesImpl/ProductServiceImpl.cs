using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;
using Org.BouncyCastle.Crypto;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MyApp.Services.ServicesImpl
{
    public class ProductServiceImpl : ProductService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductServiceImpl(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _dbContext.Product.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                throw new ValidationException("Product not found");
            }
            _dbContext.Product.Remove(product);
            await _dbContext.SaveChangesAsync();
            return null;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            return _mapper.Map<List<ProductDto>>(await _dbContext.Product.
               Include(p => p.Type).
               Include(p => p.Attributes).
               Include(p => p.Unit).
               ToListAsync());
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            return (await _dbContext.Product.FindAsync(id)) is var attribute ?
               _mapper.Map<ProductDto>(attribute) :
               null;
        }

        public async Task<ProductDto> AddProduct(ProductRequest productRequest)
        {
            var product = _mapper.Map<Models.Entities.Product>(productRequest);

            await _dbContext.Product.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

    }
}
