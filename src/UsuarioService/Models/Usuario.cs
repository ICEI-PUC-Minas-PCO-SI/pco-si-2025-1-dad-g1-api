using System.ComponentModel.DataAnnotations;
using UsuarioService.Enums;

namespace UsuarioService.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string SenhaHash { get; set; } 
        [Required] // Role é obrigatória
        public PapelUsuario Papel { get; set; } = PapelUsuario.Participante; // Valor padrão, se desejar
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    }
}