using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SerilogElasticKibanaCore.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]
        public double Number1 { get; set; }

        [BindProperty]
        public double Number2 { get; set; }

        public double Result { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Result = Number1 / Number2;
        }
    }
}
