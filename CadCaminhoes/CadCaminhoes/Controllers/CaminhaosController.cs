using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadCaminhoes.Data;
using CadCaminhoes.Models;

namespace CadCaminhoes.Views
{
    public class CaminhaosController : Controller
    {
        private readonly CaminhaoContext _context;

        public CaminhaosController(CaminhaoContext context)
        {
            _context = context;
        }
        // GET: Caminhaos
        public async Task<IActionResult> Index()
        {
            var anoAtual = DateTime.Now;
            
            var caminhaoContext = _context.Caminhoes.Include(c => c.Modelo);
                //.Where(c => c.AnoFabricacao.Equals( ))
            //    .Where(c => c.Modelo.DataModelo >="2021");
            return View(await caminhaoContext.ToListAsync());
        }

        // GET: Caminhaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes
                .Include(c => c.Modelo)
                .Where(c => c.Modelo.Permitido)
                .FirstOrDefaultAsync(m => m.CaminhaoID == id);

            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // GET: Caminhaos/Create
        public IActionResult Create()
        {
            var list = (_context.Modelos).Where(c => c.Permitido);

            ViewData["ModeloID"] = new SelectList(list, "ID", "Tipo");

            return View();
        }

        // POST: Caminhaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AnoFabricacao,Descricao, ModeloID, Permitido")] Caminhao caminhao)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(caminhao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModeloID"] = new SelectList(_context.Modelos, "ID", "Tipo", caminhao.ModeloID);
            return View(caminhao);
        }

        // GET: Caminhaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var caminhao = await _context.Caminhoes
                            .Include(c => c.Modelo)
                .Where(c => c.CaminhaoID == id)
                .Where(c => c.Modelo.Permitido)
                .FirstOrDefaultAsync();
            if (caminhao == null)
            {
                return NotFound();
            }
            ViewData["ModeloID"] = new SelectList(_context.Modelos, "ID", "Tipo", caminhao.ModeloID);
            return View(caminhao);

        }

        // POST: Caminhaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaminhaoID,AnoFabricacao,Descricao,ModeloID")] Caminhao caminhao)
        {
            if (id != caminhao.CaminhaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caminhao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaminhaoExists(caminhao.CaminhaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewData["ModeloID"] = new SelectList(_context.Modelos, "ID", "Tipo", caminhao.ModeloID);
                return RedirectToAction(nameof(Index));
            }
            return View(caminhao);
        }

        // GET: Caminhaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caminhao = await _context.Caminhoes
                .FirstOrDefaultAsync(m => m.CaminhaoID == id);
            if (caminhao == null)
            {
                return NotFound();
            }

            return View(caminhao);
        }

        // POST: Caminhaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caminhao = await _context.Caminhoes.FindAsync(id);
            _context.Caminhoes.Remove(caminhao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaminhaoExists(int id)
        {
            return _context.Caminhoes.Any(e => e.CaminhaoID == id);
        }
    }
}
