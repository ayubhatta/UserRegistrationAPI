using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using NewUser.Models;  // Adjust namespace according to your project structure
using NewUser.Data;    // Adjust namespace according to your project structure

namespace NewUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/Users/Register
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.email == user.email || u.phoneNumber == user.phoneNumber))
            {
                return BadRequest("Email or PhoneNumber already exists.");
            }

            user.password = BCrypt.Net.BCrypt.HashPassword(user.password); // Hash the password before saving

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] LoginDto loginDto)
        {
            // Find the user by email
            var user = await _context.Users.SingleOrDefaultAsync(u => u.email == loginDto.email);

            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Verify the password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.password, user.password);

            if (!isPasswordValid)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Generate a token or return user information (for demonstration, returning user info)
            return Ok(user);
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
