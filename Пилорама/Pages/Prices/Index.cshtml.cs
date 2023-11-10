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
    public class IndexModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public IndexModel(Пилорама.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Price> Price { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Prices != null)
            {
                Price = await _context.Prices.ToListAsync();
            }
        }
    }
}
