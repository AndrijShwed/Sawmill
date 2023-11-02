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

        int Номер;

        public IndexModel(Пилорама.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;
        public IList<Work> Work { get;set; } = default!;
        [Authorize]
        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders.ToListAsync();
               
            }
            if (_context.Work != null)
            {
                Work = await _context.Work.ToListAsync();
                  
            }
            Номер = Work.Count;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            

            foreach (var item in _context.Orders)
            {
                if (item.Замовник == User.Identity.Name)
                {
                    item.Статус = "На підтвердженні";
                    item.НомерЗамовлення = Номер;
                   
                }
            }

            Work work = new Work() { Client = User.Identity.Name, OrderNumber = Номер };
            
            _context.Work.Add(work);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Підтвердити");
        }

    }
}
