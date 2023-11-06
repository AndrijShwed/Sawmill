using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Пилорама.Models;

namespace Пилорама.Pages.Orders
{
    public class Index1Model : PageModel
    {

        private readonly Пилорама.Data.ApplicationDbContext _context;

        int Номер = 0;

        public Index1Model(Пилорама.Data.ApplicationDbContext context)
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
