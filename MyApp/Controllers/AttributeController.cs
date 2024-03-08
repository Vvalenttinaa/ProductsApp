using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;
using MyApp.Services;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttributeController : ControllerBase
    {
        private readonly AttributeService _service;

        public AttributeController(AttributeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<AttributeDto>> AddAttribute(AttributeRequest attributeRequest)
        {

            var attributeDTO = await _service.AddAttribute(attributeRequest);
            if (attributeDTO == null)
            {
                ModelState.AddModelError("Type", "Invalid Attribute");
                return BadRequest(ModelState);
            }
            return CreatedAtAction(nameof(GetAttribute), new { id = attributeDTO.Id }, attributeDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeDto>> GetAttribute(int id)
        {
            return (await _service.GetAttribute(id)) is var attribute ? Ok(attribute) : NotFound();
        }
    }
}
