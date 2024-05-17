using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.ServicePPs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ServicePP> ServicePP { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ServicePPs != null)
            {
                ServicePP = await _context.ServicePPs.ToListAsync();
            }
        }

    }
}
