using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;
        public IList<ServicePP> ServicePPs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Services != null)
            {
                Service = await _context.Services.ToListAsync();
            }
            if (_context.ServicePPs != null)
            {
                ServicePPs = await _context.ServicePPs.ToListAsync();
            }
        }
       
    }
}
