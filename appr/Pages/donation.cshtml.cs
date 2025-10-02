using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using appr.Data; // Assuming this is where ApplicationDbContext lives
using appr.Models; // Assuming this is where the Donation model lives
using System.Threading.Tasks;

namespace appr.Pages
{
    public class donationModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Dependency Injection: EF Core injects the database context
        public donationModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // BindProperty receives the data from the HTML form post
        [BindProperty]
        public Donation Donation { get; set; } = new Donation();

        // Standard GET method (page load)
        public void OnGet()
        {
            // Initialize the default On-Site Location here (optional but cleaner)
            Donation.OnSiteLocation = "1188 Beitel Rd, Robertville, Roodepoort, 1709, South Africa";
        }

        // Handler for POST requests (when the user clicks the "Send" button)
        public async Task<IActionResult> OnPost()
        {
            // --- 1. Validate the form data against the C# model attributes ---
            if (!ModelState.IsValid)
            {
                // If validation fails (e.g., a required field is missing), return to the page 
                // to display validation messages.
                return Page();
            }

            // --- 2. Database Insertion Logic ---

            // You can set the DonationDate and UserID here if needed
            Donation.DonationDate = DateTime.Now;
            // Donation.UserID = User.Identity.IsAuthenticated ? GetCurrentUserId() : (int?)null;

            _context.Donations.Add(Donation);

            // Save all changes to the database (executes the SQL INSERT command)
            await _context.SaveChangesAsync();

            // --- 3. Post-Redirect-Get Pattern ---

            // Use TempData to show a success message after the redirect
            TempData["Message"] = "Thank you for your generous donation! We have successfully recorded your details.";

            // Redirect back to the same page to prevent duplicate form submissions
            return RedirectToPage();
        }
    }
}