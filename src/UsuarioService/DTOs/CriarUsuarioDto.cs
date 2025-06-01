using System.ComponentModel.DataAnnotations;
using UsuarioService.Enums;

namespace UsuarioService.DTOs
{
    public class CriarUsuarioDto
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome de usuário não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode exceder 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 255 caracteres.")]
        public string Senha { get; set; } // Recebe a senha em texto puro aqui

        [Required(ErrorMessage = "A função do usuário é obrigatória.")]
        [EnumDataType(typeof(PapelUsuario), ErrorMessage = "Função inválida.")]
        public PapelUsuario Papel { get; set; } = PapelUsuario.Participante; 
    }
}