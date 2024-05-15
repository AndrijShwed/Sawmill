using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.ServicePPs
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public ServicePP ServicePP { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == 0 || _context.ServicePPs == null)
            {
                return NotFound();
            }

            var servicepp = await _context.ServicePPs.FirstOrDefaultAsync(m => m.Id == id);
            if (servicepp == null)
            {
                return NotFound();
            }
            else 
            {
                ServicePP = servicepp;
            }
            return Page();
        }
    }
}
