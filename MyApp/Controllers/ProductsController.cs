using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;
using MyApp.Services;
using System;
using Microsoft.OpenApi.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct(ProductRequest productRequest)
        {

            var productDTO = await _service.AddProduct(productRequest);
            if (productDTO == null)
            {
                ModelState.AddModelError("Type", "Invalid Attribute");
                return BadRequest(ModelState);
            }
            return CreatedAtAction(nameof(GetProduct), new { id = productDTO.Id }, productDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            return (await _service.GetProduct(id)) is var product ? Ok(product) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var productDTO = await _service.DeleteProduct(id);
                return NoContent();
            }
            catch (OpenApiException ex)
            {
                
                return StatusCode(500, ex.Message);
                
            }
        }

    }
}
