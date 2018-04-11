using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsuarioModelsController : Controller
    {
        private readonly MeuContext _context;

        public UsuarioModelsController(MeuContext context)
        {
            _context = context;
        }

        // GET: UsuarioModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuarioModel.ToListAsync());
        }

        // GET: UsuarioModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET: UsuarioModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Nome,Senha,CPF,Aniversario")] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.HashPassword(); //CRIPTOGRAFA SENHA
                _context.Add(usuarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: UsuarioModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel.SingleOrDefaultAsync(m => m.ID == id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            usuarioModel.Senha = "";  //ADICIONADO PARA FORCAR O USUARIO A COLOCAR UM NOVO PASSWORD
            return View(usuarioModel);
        }

        // POST: UsuarioModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Nome,Senha,CPF,Aniversario")] UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuarioModel.HashPassword(); //CRIPTOGRAFA SENHA
                    _context.Update(usuarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: UsuarioModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioModel = await _context.UsuarioModel
                .SingleOrDefaultAsync(m => m.ID == id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // POST: UsuarioModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuarioModel = await _context.UsuarioModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.UsuarioModel.Remove(usuarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.UsuarioModel.Any(e => e.ID == id);
        }
    }
}
