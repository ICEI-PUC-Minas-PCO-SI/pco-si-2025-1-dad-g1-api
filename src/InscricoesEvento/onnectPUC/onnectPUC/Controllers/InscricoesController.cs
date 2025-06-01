
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InscricaoService.Data;
using InscricaoService.Models;

namespace InscricaoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricoesController : ControllerBase
    {
        private readonly InscricaoContext _context;

        public InscricoesController(InscricaoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Inscricao>> CriarInscricao([FromBody] Inscricao inscricao)
        {
            bool existe = await _context.Inscricoes
                .AnyAsync(i => i.EventoId == inscricao.EventoId && i.UsuarioId == inscricao.UsuarioId);

            if (existe)
                return Conflict("Usuário já inscrito nesse evento.");

            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = inscricao.Id }, inscricao);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inscricao>> ObterPorId(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
                return NotFound();

            return inscricao;
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> ListarPorUsuario(Guid usuarioId)
        {
            return await _context.Inscricoes
                .Where(i => i.UsuarioId == usuarioId)
                .ToListAsync();
        }

        [HttpGet("evento/{eventoId}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> ListarPorEvento(Guid eventoId)
        {
            return await _context.Inscricoes
                .Where(i => i.EventoId == eventoId)
                .ToListAsync();
        }

        [HttpGet("checar/{eventoId}/{usuarioId}")]
        public async Task<ActionResult<bool>> VerificarInscricao(Guid eventoId, Guid usuarioId)
        {
            var inscrito = await _context.Inscricoes
                .AnyAsync(i => i.EventoId == eventoId && i.UsuarioId == usuarioId && i.Ativa);

            return Ok(inscrito);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelarInscricao(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null) return NotFound();

            inscricao.Ativa = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("total/{eventoId}")]
        public async Task<ActionResult<int>> TotalInscritos(Guid eventoId)
        {
            int total = await _context.Inscricoes
                .CountAsync(i => i.EventoId == eventoId && i.Ativa);

            return Ok(total);
        }
    }
}
