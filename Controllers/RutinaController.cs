using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.DTOs.Rutina;
using Security.Services;

namespace Security.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutinaController : ControllerBase
    {
        private readonly IRutinaService _service;

        public RutinaController(IRutinaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rutinas = await _service.GetAllAsync();
            return Ok(rutinas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRutinaDto dto)
        {
            // Tomamos el claim "id" del JWT (debe contener el Guid del usuario)
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("No se encontró el id del usuario en el token.");

            if (!Guid.TryParse(userIdClaim, out var userId))
                return Unauthorized("El id del usuario en el token no es un Guid válido.");

            var rutina = await _service.CreateAsync(dto, userId);
            return Ok(rutina);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRutinaDto dto)
        {
            var rutina = await _service.UpdateAsync(id, dto);
            if (rutina == null) return NotFound();
            return Ok(rutina);
        }

        [Authorize(Roles = "Trainer")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
