using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsuarioService.Data;
using UsuarioService.DTOs;
using UsuarioService.Interfaces;
using UsuarioService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCrypt.Net; // Para hashing de senha

namespace UsuarioService.Services
{
    public class UserService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<LerUsuarioDto> CreateUserAsync(CriarUsuarioDto criarUsuarioDto)
        {
            // Verifica se o usuário ou e-mail já existem
            if (await _context.Usuarios.AnyAsync(u => u.Nome == criarUsuarioDto.Nome || u.Email == criarUsuarioDto.Email))
            {
                return null; // Indica que o usuário/e-mail já existe
            }

            var user = _mapper.Map<Usuario>(criarUsuarioDto);
            user.SenhaHash = BCrypt.Net.BCrypt.HashPassword(criarUsuarioDto.Senha); // Hashing da senha

            _context.Usuarios.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<LerUsuarioDto>(user);
        }

        public async Task<IEnumerable<LerUsuarioDto>> GetAllUsersAsync()
        {
            var users = await _context.Usuarios.ToListAsync();
            return _mapper.Map<IEnumerable<LerUsuarioDto>>(users);
        }

        public async Task<LerUsuarioDto> GetUserByIdAsync(int userId)
        {
            var user = await _context.Usuarios.FindAsync(userId);
            return _mapper.Map<LerUsuarioDto>(user);
        }

        public async Task<bool> UpdateUserAsync(int userId, AtualizarUsuarioDto userUpdateDto)
        {
            var user = await _context.Usuarios.FindAsync(userId);
            if (user == null)
            {
                return false; // Usuário não encontrado
            }

            // Verifica se o novo username ou e-mail já existem, excluindo o próprio usuário
            if (!string.IsNullOrEmpty(userUpdateDto.Nome) && userUpdateDto.Nome != user.Nome &&
                await _context.Usuarios.AnyAsync(u => u.Nome == userUpdateDto.Nome))
            {
                return false; // Username já em uso
            }

            if (!string.IsNullOrEmpty(userUpdateDto.Email) && userUpdateDto.Email != user.Email &&
                await _context.Usuarios.AnyAsync(u => u.Email == userUpdateDto.Email))
            {
                return false; // Email já em uso
            }

            // Mapeia as propriedades atualizadas do DTO para o modelo existente
            // Excluímos a senha aqui, ela será tratada separadamente
            _mapper.Map(userUpdateDto, user);

            if (!string.IsNullOrEmpty(userUpdateDto.Senha))
            {
                user.SenhaHash = BCrypt.Net.BCrypt.HashPassword(userUpdateDto.Senha);
            }

            //user.UpdatedAt = DateTime.UtcNow; // Atualiza a data de modificação

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(userId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.Usuarios.FindAsync(userId);
            if (user == null)
            {
                return false; // Usuário não encontrado
            }

            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioAuthResponseDto> AuthenticateUserAsync(string Email, string senha)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(senha, user.SenhaHash))
            {
                return null; // Autenticação falhou
            }

            // Se a autenticação for bem-sucedida, gere o JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]);
            var issuer = _configuration["JwtSettings:Issuer"];
            var audience = _configuration["JwtSettings:Audience"];

            // Adiciona as claims (informações)
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // ID do usuário
                new Claim(ClaimTypes.Name, user.Nome), // Nome de usuário
                new Claim(ClaimTypes.Email, user.Email), // E-mail do usuário
                new Claim(ClaimTypes.Role, user.Papel.ToString()) // Função/Role do usuário (Criador, Participante, Admin)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2), // Token expira em 2 horas 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new UsuarioAuthResponseDto
            {
                Usuario = _mapper.Map<LerUsuarioDto>(user),
                Token = tokenString
            };
        }

        private async Task<bool> UserExists(int id)
        {
            return await _context.Usuarios.AnyAsync(e => e.Id == id);
        }
    }
}