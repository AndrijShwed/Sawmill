using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Пилорама.Data;
using Пилорама.Models;

namespace Пилорама.Pages.Prices
{
    public class DeleteModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public DeleteModel(Пилорама.Data.ApplicationDbContext context)
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
