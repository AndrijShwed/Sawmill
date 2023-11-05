using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Пилорама.Data;
using Пилорама.Models;

namespace Пилорама.Pages.Numbers
{
    public class DetailsModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public DetailsModel(Пилорама.Data.ApplicationDbContext context)
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
