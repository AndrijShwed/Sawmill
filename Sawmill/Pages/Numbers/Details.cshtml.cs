using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.Numbers
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public Number Number { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Numbers == null)
            {
                return NotFound();
            }

            var number = await _context.Numbers.FirstOrDefaultAsync(m => m.id == id);
            if (number == null)
            {
                return NotFound();
            }
            else 
            {
                Number = number;
            }
            return Page();
        }
    }
}
