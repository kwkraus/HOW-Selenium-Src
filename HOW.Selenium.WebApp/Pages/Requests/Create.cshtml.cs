using HOW.Selenium.WebApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace HOW.Selenium.WebApp.Pages.Requests
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly HOW.Selenium.WebApp.Data.ApplicationDbContext _context;

        public CreateModel(HOW.Selenium.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Request Request { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Requests.Add(Request);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
