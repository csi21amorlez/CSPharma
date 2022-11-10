﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL_CSPharma.Models;

namespace CSPharma.Controllers
{
    public class TdcCatEstadosPagoPedidoesController : Controller
    {
        private readonly CspharmaInformacionalContext _context;

        public TdcCatEstadosPagoPedidoesController(CspharmaInformacionalContext context)
        {
            _context = context;
        }

        // GET: TdcCatEstadosPagoPedidoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TdcCatEstadosPagoPedidos.ToListAsync());
        }

        // GET: TdcCatEstadosPagoPedidoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TdcCatEstadosPagoPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosPagoPedido = await _context.TdcCatEstadosPagoPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tdcCatEstadosPagoPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosPagoPedido);
        }

        // GET: TdcCatEstadosPagoPedidoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TdcCatEstadosPagoPedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MdUuid,MdDate,Id,CodEstadoPago,DesEstadoPago")] TdcCatEstadosPagoPedido tdcCatEstadosPagoPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tdcCatEstadosPagoPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tdcCatEstadosPagoPedido);
        }

        // GET: TdcCatEstadosPagoPedidoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TdcCatEstadosPagoPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosPagoPedido = await _context.TdcCatEstadosPagoPedidos.FindAsync(id);
            if (tdcCatEstadosPagoPedido == null)
            {
                return NotFound();
            }
            return View(tdcCatEstadosPagoPedido);
        }

        // POST: TdcCatEstadosPagoPedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MdUuid,MdDate,Id,CodEstadoPago,DesEstadoPago")] TdcCatEstadosPagoPedido tdcCatEstadosPagoPedido)
        {
            if (id != tdcCatEstadosPagoPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tdcCatEstadosPagoPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TdcCatEstadosPagoPedidoExists(tdcCatEstadosPagoPedido.Id))
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
            return View(tdcCatEstadosPagoPedido);
        }

        // GET: TdcCatEstadosPagoPedidoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TdcCatEstadosPagoPedidos == null)
            {
                return NotFound();
            }

            var tdcCatEstadosPagoPedido = await _context.TdcCatEstadosPagoPedidos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tdcCatEstadosPagoPedido == null)
            {
                return NotFound();
            }

            return View(tdcCatEstadosPagoPedido);
        }

        // POST: TdcCatEstadosPagoPedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TdcCatEstadosPagoPedidos == null)
            {
                return Problem("Entity set 'CspharmaInformacionalContext.TdcCatEstadosPagoPedidos'  is null.");
            }
            var tdcCatEstadosPagoPedido = await _context.TdcCatEstadosPagoPedidos.FindAsync(id);
            if (tdcCatEstadosPagoPedido != null)
            {
                _context.TdcCatEstadosPagoPedidos.Remove(tdcCatEstadosPagoPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TdcCatEstadosPagoPedidoExists(long id)
        {
            return _context.TdcCatEstadosPagoPedidos.Any(e => e.Id == id);
        }
    }
}
