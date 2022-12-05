using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL_CSPharma.Models;

namespace CSPharma.Pages.EstadoDevolucion
{
    public class ListEstadoDevolucionModel : PageModel
    {
        private readonly DAL_CSPharma.Models.CspharmaInformacionalContext _context;

        public ListEstadoDevolucionModel(DAL_CSPharma.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<TdcCatEstadosDevolucionPedido> TdcCatEstadosDevolucionPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatEstadosDevolucionPedidos != null)
            {
                TdcCatEstadosDevolucionPedido = await _context.TdcCatEstadosDevolucionPedidos.ToListAsync();
            }
        }
    }
}
