using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Пилорама.Models;

namespace Пилорама.Pages.Numbers
{
    public class CreateModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public CreateModel(Пилорама.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Number> Numberm { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Numbers != null)
            {
                Numberm = await _context.Numbers.ToListAsync();
            }
            
        }

        [BindProperty]
        public Number Number { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Numbers == null || Number == null)
            {
                return Page();
            }

            _context.Numbers.Add(Number);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Orders/Підтвердити");
        }
    }
}
