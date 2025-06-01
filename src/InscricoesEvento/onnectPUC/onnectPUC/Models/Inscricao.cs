
namespace InscricaoService.Models
{
    public class Inscricao
    {
        public int Id { get; set; }
        public Guid EventoId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime DataInscricao { get; set; } = DateTime.UtcNow;
        public bool Ativa { get; set; } = true;
    }
}
