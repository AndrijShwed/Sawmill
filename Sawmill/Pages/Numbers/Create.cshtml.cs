﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;
using Sawmill.Core;
using Microsoft.AspNetCore.Identity;

namespace Sawmill.Pages.Numbers
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
       
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Number> Numberm { get; set; } = new List<Number>();

        public string? Phone { get; set; } = default!;
        public int Номер { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Numbers.Any())
            {
                Numberm = await _context.Numbers.ToListAsync();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                Phone = await _userManager.GetPhoneNumberAsync(user);
            }
            else
            {
                Phone = "Не вдалося отримати номер телефону користувача";
            }
        }

        [BindProperty]
        public Number Number { get; set; } = default!;
        readonly EmailService email = new();
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Numbers == null || Number == null)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Не вдається завантажити користувача з ID '{_userManager.GetUserId(User)}'.");
            }
            else
            {
                await _userManager.SetPhoneNumberAsync(user, Number.Номер_телефону);
            }
            string client = Number.Ім_я +", "+ Number.Населений_пункт +", тел: "+ Number.Номер_телефону;
            _context.Numbers.Add(Number);

            if (_context.Numbers.Any())
            {
                Номер = _context.Numbers.ToList().Last().id + 1;
            }
            else
            {
                Номер = 1;
            }

            foreach (var item in _context.Orders)
            {
                if (item.Замовник == User.Identity?.Name && item.NumberId == 0)
                {

                    item.NumberId = Номер;

                }
            }

            await _context.SaveChangesAsync();
            await email.SendEmailAsync_Order(client);
            return RedirectToPage("/Orders/Підтвердити");
        }
    }
}
