using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public void OnGet()
        {
            if (_context.Products.Any())
            {
                Products = _context.Products.ToList();
            }
        }
    }
}