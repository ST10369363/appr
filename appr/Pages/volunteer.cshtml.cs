using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appr.Data;
using appr.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Needed for async methods

// Alias your Task model to avoid conflict
using TaskModel = appr.Models.Task;

namespace appr.Pages
{
    public class volunteerModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public volunteerModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Bind the volunteer form
        [BindProperty]
        public Volunteer VolunteerApplication { get; set; } = new Volunteer();

        // List of tasks for dropdown
        public List<TaskModel> AvailableTasks { get; set; } = new List<TaskModel>();

        // GET: populate tasks dropdown
        public async System.Threading.Tasks.Task OnGetAsync()
        {
            // Fully qualify TaskModel in query for clarity
            AvailableTasks = await _context.Tasks
                .Where(t => t.IsActive)
                .OrderBy(t => t.TaskName)
                .ToListAsync();
        }

        // POST: handle form submission
        public async System.Threading.Tasks.Task<IActionResult> OnPostAsync()
        {
            // Repopulate tasks in case validation fails
            await OnGetAsync();

            if (!VolunteerApplication.Accept)
            {
                ModelState.Clear();
                VolunteerApplication.TaskID = null; // No task selected
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    TempData["Message"] = "Please check all fields and ensure a task is selected.";
                    TempData["MessageType"] = "danger";
                    return Page();
                }
            }

            // Set timestamp
            VolunteerApplication.DateApplied = System.DateTime.Now;

            _context.Volunteers.Add(VolunteerApplication);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Thank you! Your volunteer application has been successfully submitted.";
            TempData["MessageType"] = "success";

            return RedirectToPage();
        }
    }
}
