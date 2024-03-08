using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models.DTOs;
using MyApp.Models.Requests;
using MyApp.Services;

namespace MyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AttributeNameController : ControllerBase
    {
        private readonly AttributeNameService _service;

        public AttributeNameController(AttributeNameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<AttributeNameDto>> AddAttribute(AttributeNameRequest attributeRequest)
        {

            var attributeDTO = await _service.AddAttributeName(attributeRequest);
            if (attributeDTO == null)
            {
                ModelState.AddModelError("Type", "Invalid Attribute");
                return BadRequest(ModelState);
            }
            return CreatedAtAction(nameof(GetAttributeName), new { id = attributeDTO.Id }, attributeDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttributeNameDto>> GetAttributeName(int id)
        {
            return (await _service.GetAttributeName(id)) is var attribute ? Ok(attribute) : NotFound();
        }
    }
}
