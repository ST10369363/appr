using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using appr.Data;
using appr.Models;

namespace appr.Pages
{
    public class reportModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public IncidentReport NewReport { get; set; } = new IncidentReport();

        public reportModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.IncidentReports.Add(NewReport);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Incident Report submitted successfully!";
            return RedirectToPage();
        }
    }
}
