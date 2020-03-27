using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HOW.Selenium.WebApp.Pages
{
    [Authorize]
    public class RequestModel : PageModel
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public void OnGet()
        {

        }
    }
}