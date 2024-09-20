using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Sawmill.Data;
using Sawmill.Models;
namespace Sawmill.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Product>Products { get; set; } = new List<Product>();
        public IList<Contact>Contacts { get; set; } = new List<Contact>();

        public void OnGet()
        {
            if (_context.Products.Any())
            {
                Products = _context.Products.ToList();
            }

            if (_context.Contacts.Any())
            {
                Contacts = _context.Contacts.ToList();
            }
        }
       
    }
}