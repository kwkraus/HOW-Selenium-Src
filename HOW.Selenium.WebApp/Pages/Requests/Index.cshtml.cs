using HOW.Selenium.WebApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HOW.Selenium.WebApp.Pages.Requests
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HOW.Selenium.WebApp.Data.ApplicationDbContext _context;

        public IndexModel(HOW.Selenium.WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Request> Request { get;set; }

        public async Task OnGetAsync()
        {
            Request = await _context.Requests.ToListAsync();
        }
    }
}
