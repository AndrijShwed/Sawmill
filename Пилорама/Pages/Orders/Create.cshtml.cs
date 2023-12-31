﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Пилорама.Data;
using Пилорама.Models;

namespace Пилорама.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Пилорама.Data.ApplicationDbContext _context;

        public CreateModel(Пилорама.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Ціна"] = _context.Prices.ToList().Last().Ціна;
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
