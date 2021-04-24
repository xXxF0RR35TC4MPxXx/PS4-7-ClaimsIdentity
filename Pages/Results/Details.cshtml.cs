using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PS4_7_ClaimsIdentity.Data;
using PS4_7_ClaimsIdentity.Models;

namespace PS4_7_ClaimsIdentity.Results
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly FBContext _context;

        public DetailsModel(FBContext context)
        {
            _context = context;
        }

        public FizzBuzz FizzBuzz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FizzBuzz = await _context.FizzBuzz.FirstOrDefaultAsync(m => m.Id == id);

            if (FizzBuzz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
