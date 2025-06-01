
using Microsoft.EntityFrameworkCore;
using InscricaoService.Models;

namespace InscricaoService.Data
{
    public class InscricaoContext : DbContext
    {
        public InscricaoContext(DbContextOptions<InscricaoContext> options) : base(options) { }

        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inscricao>()
                .HasIndex(i => new { i.EventoId, i.UsuarioId })
                .IsUnique();
        }
    }
}
