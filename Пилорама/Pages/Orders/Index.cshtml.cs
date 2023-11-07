using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Пилорама.Data;
using Пилорама.Models;

namespace Пилорама.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        int Номер = 0;

        public IndexModel(Пилорама.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;
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
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_context.Numbers != null)
            {
                Номер = _context.Numbers.ToList().Last().id + 1;
            }
            else
            {
                Номер = 1;
            }
            foreach (var item in _context.Orders)
            {
                if (item.Замовник == User.Identity.Name)
                {
                    item.Статус = "На підтвердженні";
                    item.НомерЗамовлення = Номер;
                   
                }
            }


           
            await _context.SaveChangesAsync();

            return RedirectToPage("/Numbers/Create");
        }

    }
}
