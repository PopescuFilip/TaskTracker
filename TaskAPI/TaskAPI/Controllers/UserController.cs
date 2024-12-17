using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            List<User> users = _userService.GetAll();
            return Ok(users);
        }

        /// <summary>
        /// Adds a user
        /// </summary>
        /// <param name="user">User to add</param>
        /// <returns>Created user</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _userService.Create(user);
            return Ok(user);
        }

        /// <summary>
        /// Updates a user with the specified ID
        /// </summary>
        /// <param name="id">ID of the user to update</param>
        /// <param name="user">Updated user data</param>
        /// <returns>Updated user</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            _userService.Update(id, user);
            return Ok(user);
        }

        /// <summary>
        /// Deletes a user with the specified ID
        /// </summary>
        /// <param name="id">ID of the user to delete</param>
        /// <returns>Status of deletion</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            bool deleted = _userService.Delete(id);

            if (!deleted)
                return NotFound();

            return Ok(200);
        }

        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">ID of the user to retrieve</param>
        /// <returns>Retrieved user</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var user = _userService.Get(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Dictionary<string, string> loginData)
        {
            if (loginData == null ||
                !loginData.TryGetValue("username", out var username) ||
                !loginData.TryGetValue("password", out var password) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Username and password are required.");
            }

            var userId = _userService.Check(username, password, HttpContext);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok(userId);
        }

    }
}
