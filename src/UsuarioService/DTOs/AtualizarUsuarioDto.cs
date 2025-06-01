using System.ComponentModel.DataAnnotations;

namespace UsuarioService.DTOs
{
    public class AtualizarUsuarioDto
    {
        [StringLength(100, ErrorMessage = "O nome de usuário não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode exceder 100 caracteres.")]
        public string Email { get; set; }

        [StringLength(255, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 255 caracteres.")]
        public string Senha { get; set; } // Opcional, para alteração de senha
    }
}