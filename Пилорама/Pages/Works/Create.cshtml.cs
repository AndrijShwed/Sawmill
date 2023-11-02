using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Пилорама.Data;
using Пилорама.Models;

namespace Пилорама.Pages.Works
{
    public class CreateModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public CreateModel(Пилорама.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Work Work { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Work == null || Work == null)
            {
                return Page();
            }

            _context.Work.Add(Work);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
