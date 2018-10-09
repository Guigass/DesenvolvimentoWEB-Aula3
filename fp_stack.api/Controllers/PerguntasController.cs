using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fp_stack.core.Models;
using Microsoft.AspNetCore.Cors;

namespace fp_stack.api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{apiVersion}/[controller]")]
    [ApiController]
    //[EnableCors("Default")]
    public class PerguntasController : ControllerBase
    {
        private readonly Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }

        // GET: api/Perguntas
        [HttpGet]
        public IEnumerable<Pergunta> Get()
        {
            return _context.Perguntas;
        }

        // GET: api/Perguntas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pergunta = await _context.Perguntas.FindAsync(id);

            if (pergunta == null)
            {
                return NotFound();
            }

            return Ok(pergunta);
        }

        // PUT: api/Perguntas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Pergunta pergunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pergunta.Id)
            {
                return BadRequest();
            }

            _context.Entry(pergunta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerguntaExists(id))
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

        // POST: api/Perguntas
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pergunta pergunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Perguntas.Add(pergunta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPergunta", new { id = pergunta.Id }, pergunta);
        }

        // DELETE: api/Perguntas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pergunta = await _context.Perguntas.FindAsync(id);
            if (pergunta == null)
            {
                return NotFound();
            }

            _context.Perguntas.Remove(pergunta);
            await _context.SaveChangesAsync();

            return Ok(pergunta);
        }

        private bool PerguntaExists(int id)
        {
            return _context.Perguntas.Any(e => e.Id == id);
        }
    }
}