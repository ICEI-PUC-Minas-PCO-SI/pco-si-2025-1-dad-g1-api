using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventApi.Context;
using EventApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventsController(AppDbContext context)
        {
            _context = context;
        }

        // Buscar todos os eventos
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // Buscar evento através do id
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // Buscar evento através do estado
        [Authorize]
        [HttpGet("searchByState")]
        public async Task<ActionResult<IEnumerable<Event>>> GetByState(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("A consulta não pode ser vazia.");

            var resultados = await _context.Events
                .Where(e =>
                    e.State.Contains(query))
                .ToListAsync();

            return Ok(resultados);
        }

        // Buscar evento através da cidade
        [Authorize]
        [HttpGet("searchByCity")]
        public async Task<ActionResult<IEnumerable<Event>>> GetByCity(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("A consulta não pode ser vazia.");

            var resultados = await _context.Events
                .Where(e =>
                    e.City.Contains(query))
                .ToListAsync();

            return Ok(resultados);
        }

        // Buscar evento através do nome
        [Authorize]
        [HttpGet("searchByName")]
        public async Task<ActionResult<IEnumerable<Event>>> GetByName(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("A consulta não pode ser vazia.");

            var resultados = await _context.Events
                .Where(e =>
                    e.Name.Contains(query))
                .ToListAsync();

            return Ok(resultados);
        }

        // buscar evento através do criador
        [Authorize]
        [HttpGet("searchByCreator")]
        public async Task<ActionResult<IEnumerable<Event>>> GetByCreator(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("A consulta não pode ser vazia.");

            var resultados = await _context.Events
                .Where(e =>
                    e.CreatorName.Contains(query))
                .ToListAsync();

            return Ok(resultados);
        }

        // buscar evento através da data
        [Authorize]
        [HttpGet("searchByDate")]
        public async Task<ActionResult<IEnumerable<Event>>> GetByDate(DateOnly query)
        {
            //if (string.IsNullOrWhiteSpace(query))
            //    return BadRequest("A consulta não pode ser vazia.");
            var resultados = await _context.Events
                .Where(e =>
                    e.Date.Equals(query))
                .ToListAsync();

            return Ok(resultados);
        }

        // Editar evento
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Cadastrar evento
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // Deletar evento através do id
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
