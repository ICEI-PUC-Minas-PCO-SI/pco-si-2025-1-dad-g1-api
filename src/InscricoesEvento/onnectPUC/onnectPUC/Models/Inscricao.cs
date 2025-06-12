
namespace InscricaoService.Models
{
    public class Inscricao
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataInscricao { get; set; } = DateTime.UtcNow;
        public bool Ativa { get; set; } = true;
    }
}
