using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Models;
using Sawmill.Data;

namespace Sawmill.Pages.Numbers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Number> Number { get;set; } = default!;
        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Numbers != null)
            {
                Number = await _context.Numbers.ToListAsync();
            }
            if (_context.Orders != null)
            {
                Order = await _context.Orders.ToListAsync();
            }
        }
    }
}
