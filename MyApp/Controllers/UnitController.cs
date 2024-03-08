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

    public class UnitController : ControllerBase
    {
        private readonly UnitService _service;

        public UnitController(UnitService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<UnitDto>> AddUnit(UnitRequest unitRequest)
        {

            var unitDTO = await _service.AddUnit(unitRequest);
            if (unitDTO == null)
            {
                ModelState.AddModelError("Type", "Invalid Attribute");
                return BadRequest(ModelState);
            }
            return CreatedAtAction(nameof(GetUnit), new { id = unitDTO.Id }, unitDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UnitDto>> GetUnit(int id)
        {
            return (await _service.GetUnit(id)) is var attribute ? Ok(attribute) : NotFound();
        }

        [HttpGet("findIdByName/{name}")]
        public async Task<ActionResult<int?>> FindIdByName(string name)
        {
            var unitId = await _service.FindIdByName(name);
            if (unitId.HasValue)
            {
                return Ok(unitId.Value);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("exist/{name}")]
        public async Task<ActionResult<bool>> Exist(string name)
        {
            var exists = await _service.Exist(name);
            return Ok(exists);
        }
    }
}
