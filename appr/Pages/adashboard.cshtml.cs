using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appr.Data;
using appr.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Alias your custom Task model
using TaskModel = appr.Models.Task;

namespace appr.Pages
{
    public class adashboardModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public adashboardModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // New Task bound to the form
        [BindProperty]
        public TaskModel NewTask { get; set; } = new TaskModel();

        // Data collections for dashboard
        public IList<IncidentReport> IncidentReports { get; set; } = default!;
        public IList<Volunteer> Volunteers { get; set; } = default!;
        public IList<Donation> Donations { get; set; } = default!;
        public IList<Donation> BoxRequests { get; set; } = default!;

        // ✅ FIX: Use Task<IActionResult> and return Page()
        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync()
        {
            IncidentReports = await _context.IncidentReports
                .OrderByDescending(r => r.ReportedDate)
                .ToListAsync();

            Volunteers = await _context.Volunteers
                .Include(v => v.Task)  // assumes Volunteer has Task nav property
                .OrderByDescending(v => v.DateApplied)
                .ToListAsync();

            Donations = await _context.Donations
                .OrderByDescending(d => d.DonationDate)
                .ToListAsync();

            BoxRequests = await _context.Donations
                .Where(d => d.NeedsBoxes == true)
                .OrderByDescending(d => d.DonationDate)
                .ToListAsync();

            return Page(); // ✅ Explicit return fixes "not all code paths return a value"
        }

        // ✅ Explicit Task<IActionResult> return type
        public async System.Threading.Tasks.Task<IActionResult> OnPostAddTask()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync(); // reload dashboard data
                TempData["Message"] = "Error: Please correct the task details.";
                TempData["MessageType"] = "danger";
                return Page();
            }

            _context.Tasks.Add(NewTask);
            await _context.SaveChangesAsync();

            TempData["Message"] = $"Task '{NewTask.TaskName}' successfully added!";
            TempData["MessageType"] = "success";

            return RedirectToPage();
        }
    }
}
