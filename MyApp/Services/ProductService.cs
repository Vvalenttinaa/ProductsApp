using Microsoft.AspNetCore.Mvc;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;
using System.Security.Claims;

namespace MyApp.Services
{
    public interface ProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> AddProduct(ProductRequest productRequest);
        Task<ProductDto> GetProduct(int id);
        Task<ActionResult> DeleteProduct(int id);
    }
}
