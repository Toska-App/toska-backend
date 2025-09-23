using Microsoft.AspNetCore.Mvc;
using Toska.DTOs.User;
using Toska.Services.Users;
using Toska.Utility;

namespace Toska.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }





        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto dto)
        {
            _logger.LogInformation("Received request to create user with email {Email}", MaskingHelper.MaskEmail(dto.Email));
            var created = await _userService.CreateUserAsync(dto);
            _logger.LogInformation("Successfully created user with PublicId {PublicId}", created.PublicId);
            return CreatedAtAction(nameof(GetOne), new { id = created.PublicId }, created);
        }




        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            // temporary: return NotFound to keep routing safe until you implement GetOne service.
            _logger.LogInformation("Received request to get user with PublicId {PublicId}", id);
            return NotFound();
        }

    }
}
