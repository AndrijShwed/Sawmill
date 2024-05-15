using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.Prices
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Price Price { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prices == null)
            {
                return NotFound();
            }

            var price = await _context.Prices.FirstOrDefaultAsync(m => m.Priceid == id);

            if (price == null)
            {
                return NotFound();
            }
            else 
            {
                Price = price;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Prices == null)
            {
                return NotFound();
            }
            var price = await _context.Prices.FindAsync(id);

            if (price != null)
            {
                Price = price;
                _context.Prices.Remove(Price);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
