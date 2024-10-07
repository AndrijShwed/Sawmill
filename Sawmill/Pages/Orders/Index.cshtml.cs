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

        int ЦінаПиломатеріал;
        int ЦінаЦиліндр;
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

            ЦінаПиломатеріал = _context.Prices.ToList().Last().ЦінаПиломатеріал;
            ЦінаЦиліндр = _context.Prices.ToList().Last().ЦінаЦиліндр;
            ViewData["ЦінаПиломатеріал"] = ЦінаПиломатеріал;
            ViewData["ЦінаЦиліндр"] = ЦінаЦиліндр;

            foreach (var item in _context.Orders)
            {
                if (item.Замовник == User.Identity?.Name && item.NumberId == 0 ||
                    item.SessionId == GlobalVariables.SessionId && item.NumberId == 0)
                {
                    if (item.Назва == "Брус оциліндрований")
                    {
                        item.Замовник = User.Identity?.Name;
                        item.Ціна = ЦінаЦиліндр;
                        k++;
                    }
                    else
                    {
                        item.Замовник = User.Identity?.Name;
                        item.Ціна = ЦінаПиломатеріал;
                        k++;
                    }
                }
            }

            if (k == 0)
            {
                return RedirectToPage("/Orders/Помилка_підтвердження");
            }
            else if (User.Identity.IsAuthenticated)
            {
                await _context.SaveChangesAsync();

                return RedirectToPage("/Numbers/Create");
            }
            else
            {
                TempData["ErrorMessage"] = "Будь ласка, зареєструйтесь, щоб продовжити замовлення.";

                return RedirectToAction("Register", "Account");
            }
        }

    }
}
