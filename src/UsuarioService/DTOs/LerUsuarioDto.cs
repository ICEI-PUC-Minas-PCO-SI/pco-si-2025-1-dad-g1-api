using System.ComponentModel.DataAnnotations;
using UsuarioService.Enums;

namespace UsuarioService.DTOs
{
    public class LerUsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; }
        public PapelUsuario Papel { get; set; }
    }
}