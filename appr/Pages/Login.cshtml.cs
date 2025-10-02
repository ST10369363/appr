using appr.Data; // Adjust namespace
using appr.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


public class LoginModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public LoginModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public LoginInput Input { get; set; }

    public string ErrorMessage { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == Input.Email && u.Password == Input.Password);

        if (user != null)
        {
            // Successful login
            return RedirectToPage("/home"); // Change to your target page
        }
        else
        {
            ErrorMessage = "Invalid email or password.";
            return Page();
        }
    }
}

public class LoginInput
{
    public string Email { get; set; }
    public string Password { get; set; }
}
