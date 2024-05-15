using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.Prices
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
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
    }
}
