using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toska.DTOs.User;
using Toska.Services.Users;

namespace Toska.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }




        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {

            try
            {
                var created = await _userService.CreateUserAsync(dto);
                return CreatedAtAction(nameof(GetOne), new { id = created.PublicId }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }




        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            // temporary: return NotFound to keep routing safe until you implement GetOne service.
            return NotFound();
        }

    }
}
