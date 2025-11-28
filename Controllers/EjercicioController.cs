using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Models.DTOS;
using Security.Services;

namespace Security.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EjercicioController : ControllerBase
    {
        private readonly IEjercicioService _service;

        public EjercicioController(IEjercicioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ejercicios = await _service.GetAllAsync();
            return Ok(ejercicios);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ejercicio = await _service.GetByIdAsync(id);
            if (ejercicio == null) return NotFound();
            return Ok(ejercicio);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEjercicioDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ejercicio = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ejercicio.Id }, ejercicio);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEjercicioDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ejercicio = await _service.UpdateAsync(id, dto);
            if (ejercicio == null) return NotFound();
            return Ok(ejercicio);
        }

        [Authorize(Roles = "Trainer")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
