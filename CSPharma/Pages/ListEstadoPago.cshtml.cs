using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL_CSPharma.Models;

namespace CSPharma.Pages
{
    public class ListEstadoPagoModel : PageModel
    {
        private readonly DAL_CSPharma.Models.CspharmaInformacionalContext _context;

        public ListEstadoPagoModel(DAL_CSPharma.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<TdcCatEstadosPagoPedido> TdcCatEstadosPagoPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatEstadosPagoPedidos != null)
            {
                TdcCatEstadosPagoPedido = await _context.TdcCatEstadosPagoPedidos.ToListAsync();
            }
        }
    }
}
