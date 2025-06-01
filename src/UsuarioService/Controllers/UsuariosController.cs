using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsuarioService.DTOs;
using UsuarioService.Interfaces;

namespace UserManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsuarioService _userService;

        public UsersController(IUsuarioService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LerUsuarioDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LerUsuarioDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<LerUsuarioDto>> PostUser([FromBody] CriarUsuarioDto userCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = await _userService.CreateUserAsync(userCreateDto);

            if (newUser == null)
            {
                // Isso pode ocorrer se o username ou e-mail já existirem
                return Conflict("Email já existe");
            }

            // Retorna o usuário criado com o status 201 Created e a URL para o novo recurso
            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] AtualizarUsuarioDto userUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _userService.UpdateUserAsync(id, userUpdateDto);

            if (!success)
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Conflict("Email já utilizado por outro usuario.");
            }

            return NoContent(); // 204 No Content para atualizações bem-sucedidas
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);

            if (!success)
            {
                return NotFound(); // Usuário não encontrado
            }

            return NoContent(); // 204 No Content para exclusões bem-sucedidas
        }

        // POST: api/Users/authenticate
        [HttpPost("authenticate")]
        public async Task<ActionResult<UsuarioAuthResponseDto>> Authenticate([FromBody] LoginUsuarioDto loginDto) 
        {
            var authResponse = await _userService.AuthenticateUserAsync(loginDto.Email, loginDto.Senha);

            if (authResponse == null)
            {
                return Unauthorized("Credenciais inválidas");
            }

            return Ok(authResponse); // Retorna o usuário e o token
        }
    }
}