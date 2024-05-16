using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;

namespace Sawmill.Pages.ServicePPs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ServicePP> ServicePP { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ServicePPs != null)
            {
                ServicePP = await _context.ServicePPs.ToListAsync();
            }
        }
        // Приклад для ASP.NET Core Controller
        public class YourController : Controller
        {
            public IActionResult YourAction()
            {
                // Отримати значення параметра "variable" з URL
                string variableValue = HttpContext.Request.Query["Id"];

                // Використовуйте variableValue як потрібно
                // Наприклад, передайте його до представлення для відображення в HTML

                return View();
            }
        }

    }
}
