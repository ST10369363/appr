using appr.Data;
using appr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using appr.Data;
using appr.Models;

namespace YourProject.Pages
{
    public class SignInModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SignInModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User NewUser { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Hash the password before saving
            var hasher = new PasswordHasher<User>();
            NewUser.Password = hasher.HashPassword(NewUser, NewUser.Password);

            _context.Users.Add(NewUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login");
        }
    }
}
