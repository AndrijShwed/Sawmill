using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.ServicePPs
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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

            var servicepp =  await _context.ServicePPs.FirstOrDefaultAsync(m => m.Id == id);
            if (servicepp == null)
            {
                return NotFound();
            }
            ServicePP = servicepp;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ServicePP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicePPExists(ServicePP.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServicePPExists(int id)
        {
          return (_context.ServicePPs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
