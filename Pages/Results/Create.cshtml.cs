using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS4_7_ClaimsIdentity.Data;
using PS4_7_ClaimsIdentity.Models;

namespace PS4_7_ClaimsIdentity.Results
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly PS4_7_ClaimsIdentity.Data.FBContext _context;

        public CreateModel(PS4_7_ClaimsIdentity.Data.FBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FizzBuzz.Add(FizzBuzz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
