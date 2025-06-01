using System.Collections.Generic;
using System.Threading.Tasks;
using UsuarioService.DTOs;

namespace UsuarioService.Interfaces
{
    public interface IUsuarioService
    {
        Task<LerUsuarioDto> CreateUserAsync(CriarUsuarioDto criarUsuarioDto);
        Task<IEnumerable<LerUsuarioDto>> GetAllUsersAsync();
        Task<LerUsuarioDto> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserAsync(int userId, AtualizarUsuarioDto atualizarUsuarioDto);
        Task<bool> DeleteUserAsync(int userId);
        Task<UsuarioAuthResponseDto> AuthenticateUserAsync(string usernameOrEmail, string password); // Alterado para retornar UserAuthResponseDto
    }
}