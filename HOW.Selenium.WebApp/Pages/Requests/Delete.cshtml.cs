using HOW.Selenium.WebApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HOW.Selenium.WebApp.Pages.Requests
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly HOW.Selenium.WebApp.Data.ApplicationDbContext _context;

        public DeleteModel(HOW.Selenium.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Request = await _context.Requests.FindAsync(id);

            if (Request != null)
            {
                _context.Requests.Remove(Request);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
