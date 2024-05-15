using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.AdminNumbers
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
      

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Numbers == null)
            {
                return NotFound();
            }
           
            var number = await _context.Numbers.FindAsync(id);

           
            if (number != null)
            {
                Number = number;
                _context.Numbers.Remove(Number);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
