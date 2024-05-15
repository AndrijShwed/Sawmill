using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.ServicePPs
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == 0 || _context.ServicePPs == null)
            {
                return NotFound();
            }
            var servicepp = await _context.ServicePPs.FindAsync(id);

            if (servicepp != null)
            {
                ServicePP = servicepp;
                _context.ServicePPs.Remove(ServicePP);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
