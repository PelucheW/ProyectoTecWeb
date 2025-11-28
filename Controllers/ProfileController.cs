using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Models.DTOS;
using Security.Services;
using System.Security.Claims;

namespace Security.Controllers
{
    [ApiController]
    [Route("api/v1/profile")]
    [Authorize] // Requiere que el usuario esté autenticado con un JWT válido
    public class ProfileController : ControllerBase
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService) => _userService = userService;

        /// Extrae el ID del usuario (Guid) del token JWT que lo autenticó.
        /// <returns>El Guid del usuario autenticado.</returns>
        /// <exception cref="UnauthorizedAccessException">Si el ID no se encuentra en el token.</exception>
        private Guid GetUserIdFromToken()
        {
            // ClaimTypes.NameIdentifier (o Sub) contiene el ID del usuario.
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (Guid.TryParse(idClaim, out var userId))
            {
                return userId;
            }
            // Esto no debería pasar si el token es válido, pero es una buena medida de seguridad.
            throw new UnauthorizedAccessException("ID de usuario no encontrado o inválido en el token.");
        }

        // GET /api/v1/profile
        /// Obtiene el perfil (UserProfile) del usuario actualmente autenticado.
        [HttpGet]
        public async Task<IActionResult> GetMyProfile()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var profileDto = await _userService.GetProfileByIdAsync(userId);

                if (profileDto == null) return NotFound("Perfil de usuario no encontrado.");

                return Ok(profileDto);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        // PUT /api/v1/profile
        /// Actualiza los detalles (UserProfile) del usuario actualmente autenticado.
        [HttpPut]
        public async Task<IActionResult> UpdateMyProfile([FromBody] UpdateProfileDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            try
            {
                var userId = GetUserIdFromToken();
                var updatedProfile = await _userService.UpdateProfileAsync(userId, dto);

                if (updatedProfile == null) return NotFound("Perfil no encontrado o no autorizado.");

                return Ok(updatedProfile);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }

        // DELETE /api/v1/profile
        /// Elimina la cuenta completa del usuario actualmente autenticado.
        /// (Solo para el mismo usuario, no para Admin)
        [HttpDelete]
        public async Task<IActionResult> DeleteMyProfile()
        {
            try
            {
                var userId = GetUserIdFromToken();
                var success = await _userService.DeleteUserAsync(userId);

                return success ? NoContent() : NotFound("Usuario o perfil no encontrado.");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}