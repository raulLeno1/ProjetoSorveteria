using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoSorveteria.Models;

namespace ProjetoSorveteria.Controllers
{
    public class SorvetesController : Controller
    {
        private readonly ProjetoSorveteriaContext _context;

        public SorvetesController(ProjetoSorveteriaContext context)
        {
            _context = context;
        }

        // GET: Sorvetes
        public async Task<IActionResult> Index()
        {
            var projetoSorveteriaContext = _context.Sorvete.Include(s => s.Pedido);
            return View(await projetoSorveteriaContext.ToListAsync());
        }

        // GET: Sorvetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sorvete = await _context.Sorvete
                .Include(s => s.Pedido)
                .FirstOrDefaultAsync(m => m.SorveteId == id);
            if (sorvete == null)
            {
                return NotFound();
            }

            return View(sorvete);
        }

        // GET: Sorvetes/Create
        public IActionResult Create()
        {
            //ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "NomeCliente");
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId");
            return View();
        }

        // POST: Sorvetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SorveteId,Sabor,Valor,Peso,Copo,PedidoId")] Sorvete sorvete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sorvete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", sorvete.PedidoId);
            return View(sorvete);
        }

        // GET: Sorvetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sorvete = await _context.Sorvete.FindAsync(id);
            if (sorvete == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", sorvete.PedidoId);
            return View(sorvete);
        }

        // POST: Sorvetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SorveteId,Sabor,Valor,Peso,Copo,PedidoId")] Sorvete sorvete)
        {
            if (id != sorvete.SorveteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sorvete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SorveteExists(sorvete.SorveteId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedido, "PedidoId", "PedidoId", sorvete.PedidoId);
            return View(sorvete);
        }

        // GET: Sorvetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sorvete = await _context.Sorvete
                .Include(s => s.Pedido)
                .FirstOrDefaultAsync(m => m.SorveteId == id);
            if (sorvete == null)
            {
                return NotFound();
            }

            return View(sorvete);
        }

        // POST: Sorvetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sorvete = await _context.Sorvete.FindAsync(id);
            _context.Sorvete.Remove(sorvete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SorveteExists(int id)
        {
            return _context.Sorvete.Any(e => e.SorveteId == id);
        }
    }
}
