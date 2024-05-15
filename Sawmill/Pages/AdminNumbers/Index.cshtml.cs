using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.AdminNumbers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Number> Number { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Numbers != null)
            {
                Number = await _context.Numbers.ToListAsync();
            }
        }
    }
}
