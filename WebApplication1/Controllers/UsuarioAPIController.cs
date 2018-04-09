using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [Route("api/UsuarioAPI")]
    public class UsuarioAPIController : Controller
    {
        private readonly MeuContext _context;

        public UsuarioAPIController(MeuContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioAPI
        [HttpGet]
        public IEnumerable<UsuarioModel> GetUsuarioModel()
        {
            return _context.UsuarioModel;
        }

        // GET: api/UsuarioAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioModel = await _context.UsuarioModel.SingleOrDefaultAsync(m => m.ID == id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return Ok(usuarioModel);
        }

        // PUT: api/UsuarioAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioModel([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarioModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(usuarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(id))
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

        // POST: api/UsuarioAPI
        [HttpPost]
        public async Task<IActionResult> PostUsuarioModel([FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UsuarioModel.Add(usuarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.ID }, usuarioModel);
        }

        // DELETE: api/UsuarioAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuarioModel = await _context.UsuarioModel.SingleOrDefaultAsync(m => m.ID == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            _context.UsuarioModel.Remove(usuarioModel);
            await _context.SaveChangesAsync();

            return Ok(usuarioModel);
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.UsuarioModel.Any(e => e.ID == id);
        }
    }
}