using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL_CSPharma.Models;

namespace CSPharma.Folder
{
    public class TdcCatEstadosDevolucionPedidoesController : Controller
    {
        private readonly CspharmaInformacionalContext _context;

        public TdcCatEstadosDevolucionPedidoesController(CspharmaInformacionalContext context)
        {
            _context = context;
        }

        // GET: TdcCatEstadosDevolucionPedidoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TdcCatEstadosDevolucionPedidos.ToListAsync());
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tdcCatEstadosDevolucionPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosDevolucionPedido);
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TdcCatEstadosDevolucionPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MdUuid,MdDate,Id,CodEstadoDevolucion,DesEstadoDevolucion")] TdcCatEstadosDevolucionPedido tdcCatEstadosDevolucionPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tdcCatEstadosDevolucionPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tdcCatEstadosDevolucionPedido);
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos.FindAsync(id);
            if (tdcCatEstadosDevolucionPedido == null)
            {
                return NotFound();
            }
            return View(tdcCatEstadosDevolucionPedido);
        }

        // POST: TdcCatEstadosDevolucionPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MdUuid,MdDate,Id,CodEstadoDevolucion,DesEstadoDevolucion")] TdcCatEstadosDevolucionPedido tdcCatEstadosDevolucionPedido)
        {
            if (id != tdcCatEstadosDevolucionPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tdcCatEstadosDevolucionPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TdcCatEstadosDevolucionPedidoExists(tdcCatEstadosDevolucionPedido.Id))
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
            return View(tdcCatEstadosDevolucionPedido);
        }

        // GET: TdcCatEstadosDevolucionPedidoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tdcCatEstadosDevolucionPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosDevolucionPedido);
        }

        // POST: TdcCatEstadosDevolucionPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TdcCatEstadosDevolucionPedidos == null)
            {
                return Problem("Entity set 'CspharmaInformacionalContext.TdcCatEstadosDevolucionPedidos'  is null.");
            }
            var tdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos.FindAsync(id);
            if (tdcCatEstadosDevolucionPedido != null)
            {
                _context.TdcCatEstadosDevolucionPedidos.Remove(tdcCatEstadosDevolucionPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TdcCatEstadosDevolucionPedidoExists(long id)
        {
            return _context.TdcCatEstadosDevolucionPedidos.Any(e => e.Id == id);
        }
    }
}
