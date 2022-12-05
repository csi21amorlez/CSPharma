using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL_CSPharma.Models;

namespace CSPharma.Pages.EstadoEnvio
{
    public class ListEstadoEnvioModel : PageModel
    {
        private readonly DAL_CSPharma.Models.CspharmaInformacionalContext _context;

        public ListEstadoEnvioModel(DAL_CSPharma.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IList<TdcCatEstadosEnvioPedido> TdcCatEstadosEnvioPedido { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TdcCatEstadosEnvioPedidos != null)
            {
                TdcCatEstadosEnvioPedido = await _context.TdcCatEstadosEnvioPedidos.ToListAsync();
            }
        }
    }
}
