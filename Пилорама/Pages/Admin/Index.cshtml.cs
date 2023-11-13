using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Пилорама.Models;

namespace Пилорама.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        int Номер = 0;

        public IndexModel(Пилорама.Data.ApplicationDbContext context)
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
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }


        //    Номер = _context.Numbers.ToList().Last().id + 1;

        //    foreach (var item in _context.Orders)
        //    {
        //        if (item.Замовник == User.Identity.Name)
        //        {
        //            item.Статус = "На підтвердженні";
        //            item.НомерЗамовлення = Номер;

        //        }
        //    }



        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("/Numbers/Create");
        //}

    }
}
