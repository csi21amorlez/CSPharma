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
    public class TdcCatEstadosEnvioPedidoesController : Controller
    {
        private readonly CspharmaInformacionalContext _context;

        public TdcCatEstadosEnvioPedidoesController(CspharmaInformacionalContext context)
        {
            _context = context;
        }

        // GET: TdcCatEstadosEnvioPedidoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TdcCatEstadosEnvioPedidos.ToListAsync());
        }

        // GET: TdcCatEstadosEnvioPedidoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tdcCatEstadosEnvioPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosEnvioPedido);
        }

        // GET: TdcCatEstadosEnvioPedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TdcCatEstadosEnvioPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MdUuid,MdDate,Id,CodEstadoEnvio,DesEstadoEnvio")] TdcCatEstadosEnvioPedido tdcCatEstadosEnvioPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tdcCatEstadosEnvioPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tdcCatEstadosEnvioPedido);
        }

        // GET: TdcCatEstadosEnvioPedidoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos.FindAsync(id);
            if (tdcCatEstadosEnvioPedido == null)
            {
                return NotFound();
            }
            return View(tdcCatEstadosEnvioPedido);
        }

        // POST: TdcCatEstadosEnvioPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MdUuid,MdDate,Id,CodEstadoEnvio,DesEstadoEnvio")] TdcCatEstadosEnvioPedido tdcCatEstadosEnvioPedido)
        {
            if (id != tdcCatEstadosEnvioPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tdcCatEstadosEnvioPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TdcCatEstadosEnvioPedidoExists(tdcCatEstadosEnvioPedido.Id))
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
            return View(tdcCatEstadosEnvioPedido);
        }

        // GET: TdcCatEstadosEnvioPedidoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tdcCatEstadosEnvioPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosEnvioPedido);
        }

        // POST: TdcCatEstadosEnvioPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TdcCatEstadosEnvioPedidos == null)
            {
                return Problem("Entity set 'CspharmaInformacionalContext.TdcCatEstadosEnvioPedidos'  is null.");
            }
            var tdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos.FindAsync(id);
            if (tdcCatEstadosEnvioPedido != null)
            {
                _context.TdcCatEstadosEnvioPedidos.Remove(tdcCatEstadosEnvioPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TdcCatEstadosEnvioPedidoExists(long id)
        {
            return _context.TdcCatEstadosEnvioPedidos.Any(e => e.Id == id);
        }
    }
}
