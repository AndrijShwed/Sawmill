using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Пилорама.Data;
using Пилорама.Models;

namespace Пилорама.Pages.Numbers
{
    public class EditModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public EditModel(Пилорама.Data.ApplicationDbContext context)
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

            var number =  await _context.Numbers.FirstOrDefaultAsync(m => m.id == id);
            if (number == null)
            {
                return NotFound();
            }
            Number = number;
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

            _context.Attach(Number).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumberExists(Number.id))
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

        private bool NumberExists(int id)
        {
          return (_context.Numbers?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
