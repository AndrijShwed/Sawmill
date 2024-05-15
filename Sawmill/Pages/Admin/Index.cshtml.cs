using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Models;

namespace Sawmill.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
            
        }

        public IList<Order> Order { get; set; } = default!;
        public IList<Number> Number { get; set; } = default!;
       
       

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders.ToListAsync();

            }
            if (_context.Numbers != null)
            {
                Number = await _context.Numbers.ToListAsync();

            }
          
        }
       
    }
}
