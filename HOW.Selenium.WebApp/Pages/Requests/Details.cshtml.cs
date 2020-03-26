using HOW.Selenium.WebApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HOW.Selenium.WebApp.Pages.Requests
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly HOW.Selenium.WebApp.Data.ApplicationDbContext _context;

        public DetailsModel(HOW.Selenium.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Request Request { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Request = await _context.Requests.FirstOrDefaultAsync(m => m.Id == id);

            if (Request == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
