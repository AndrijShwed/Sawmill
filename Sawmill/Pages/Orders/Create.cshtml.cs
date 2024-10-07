using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string Назва)
        {
            // Створюємо нову сесію
            HttpContext.Session.SetString("SessionId", HttpContext.Session.Id);

            // Можна зберегти ID сесії в глобальній змінній
            // Для цього вам потрібно визначити глобальну змінну
            GlobalVariables.SessionId = HttpContext.Session.Id;
            ViewData["ЦінаПиломатеріал"] = _context.Prices.ToList().Last().ЦінаПиломатеріал;
            ViewData["ЦінаЦиліндр"] = _context.Prices.ToList().Last().ЦінаЦиліндр;
            ViewData["Назва"] = Назва;
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Orders == null || Order == null)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
