using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Models;
using Sawmill.Data;

namespace Sawmill.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        int Ціна;
        int k = 0;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;
        public IList<Number> Number { get; set; } = default!;
        public IList<Price> Price { get; set; } = default!;
       
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
            if (_context.Prices != null)
            {
                Price = await _context.Prices.ToListAsync();

            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Ціна = _context.Prices.ToList().Last().Ціна;
            ViewData["Ціна"] = Ціна;

            foreach (var item in _context.Orders)
            {
                if (item.Замовник == User.Identity?.Name && item.NumberId == 0)
                {
                    
                    item.Ціна = Ціна;
                    k++;

                }
            }

            if (k == 0)
            {
                return RedirectToPage("/Orders/Помилка_підтвердження");
            }
            else
            {
                await _context.SaveChangesAsync();

                return RedirectToPage("/Numbers/Create");
            }
        }

    }
}
