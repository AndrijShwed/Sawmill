using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sawmill.Data;
using Sawmill.Models;
using Sawmill.Core;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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

        //public class InpuModel
        //{
        //    [Required]
        //    [StringLength(17, MinimumLength = 17, ErrorMessage = "Номер телефону має містити 12 цифр")]
        //    [Display(Name = "Номер_телефону")]
        //    public string Phone { get; set; }
        //}

        public IList<Number> Numberm { get; set; } = default!;

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Номер телефону має містити 12 цифр")]
        [Display(Name = "Номер_телефону")]
        public string Phone { get; set; } = default!;
        public int Номер { get; set; } = default!;
       

        public async Task OnGetAsync()
        {
            if (_context.Numbers != null)
            {
                Numberm = await _context.Numbers.ToListAsync();
            }
           
            var user = await _userManager.GetUserAsync(User);
            
            Phone = await _userManager.GetPhoneNumberAsync(user);
           
        }

        [BindProperty]
        public Number Number { get; set; } = default!;
        EmailService email = new EmailService();
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

            if (_context.Numbers.Count() != 0)
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
