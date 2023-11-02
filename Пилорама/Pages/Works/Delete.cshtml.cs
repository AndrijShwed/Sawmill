using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Пилорама.Data;
using Пилорама.Models;

namespace Пилорама.Pages.Works
{
    public class DeleteModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public DeleteModel(Пилорама.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Work Work { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Work == null)
            {
                return NotFound();
            }

            var work = await _context.Work.FirstOrDefaultAsync(m => m.Id == id);

            if (work == null)
            {
                return NotFound();
            }
            else 
            {
                Work = work;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Work == null)
            {
                return NotFound();
            }
            var work = await _context.Work.FindAsync(id);

            if (work != null)
            {
                Work = work;
                _context.Work.Remove(Work);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
