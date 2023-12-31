using Kormee_API_Recuritment.Contexts;
using Kormee_API_Recuritment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kormee_API_Recuritment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;

        public DataController(ApplicationDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        [HttpPost("Register")]
        public IActionResult Add([FromBody] Register register)
        {
            if (register == null)
            {
                return BadRequest("Invalid data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _dbContext.Registers.Add(register);
                _dbContext.SaveChanges();

                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest("Invalid data");
            }

            // Validation
            if (string.IsNullOrWhiteSpace(login.Username) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest("Username and password are required.");
            }

            try
            {
                var register = _dbContext.Registers
                    .FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

                if (register == null)
                {
                    return BadRequest("Invalid username or password.");
                }

                return Ok("Login successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
