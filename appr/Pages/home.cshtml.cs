using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using appr.Data;
using appr.Models;
using System.Linq;

// Explicitly alias your model Task to avoid confusion
using TaskModel = appr.Models.Task;

namespace appr.Pages
{
    public class homeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public homeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Properties to hold key database information
        public int TotalVolunteers { get; set; }
        public int TotalDonations { get; set; }
        public int TotalIncidentReports { get; set; }
        public IncidentReport? LatestIncident { get; set; }

        // ✅ FIXED: Return type should be Task<IActionResult>
        public async System.Threading.Tasks.Task<IActionResult> OnGetAsync()
        {
            // 1. Fetch Counts
            TotalVolunteers = await _context.Volunteers.CountAsync();
            TotalDonations = await _context.Donations.CountAsync();
            TotalIncidentReports = await _context.IncidentReports.CountAsync();

            // 2. Fetch Latest Incident Report for display
            LatestIncident = await _context.IncidentReports
                .OrderByDescending(r => r.ReportedDate)
                .FirstOrDefaultAsync();

            // ✅ FIXED: Explicitly return Page()
            return Page();
        }
    }
}
