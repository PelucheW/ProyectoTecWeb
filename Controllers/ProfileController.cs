using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Models.DTOS;
using Security.Services;
using System.Security.Claims;

namespace Security.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _service;

        public ProfileController(IUserService service)
        {
            _service = service;
        }

        // Obtener el perfil del usuario actual
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userIdClaim = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");

            if (userIdClaim is null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);

            var profile = await _service.GetProfileByIdAsync(userId);

            if (profile is null)
            {
                // Si no hay perfil aún, respondemos 200 con un indicador
                return Ok(new { hasProfile = false });
            }

            return Ok(profile);
        }

        // Actualizar o crear perfil
        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] UpdateProfileDto dto)
        {
            var userIdClaim = User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier || c.Type == "sub");

            if (userIdClaim is null)
                return Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);

            var result = await _service.UpdateProfileAsync(userId, dto);

            if (result is null)
                return BadRequest("No se pudo actualizar el perfil.");

            return Ok(result); // 200 con JSON del perfil actualizado
        }
    }
}
