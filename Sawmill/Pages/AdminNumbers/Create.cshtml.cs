using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.AdminNumbers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
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

            return RedirectToPage("./Index");
        }
    }
}
