using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PS4_7_ClaimsIdentity.Results;
using PS4_7_ClaimsIdentity.Data;
using PS4_7_ClaimsIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PS4_7_ClaimsIdentity.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly FBContext _context;

        [BindProperty]
        public FizzBuzz FizzBuzzResult { get; set; }

        public string UserName()
        {
            if (!String.IsNullOrEmpty(User.Identity.Name))
                return User.Identity.Name.Split('@')[0];
            else return "User";
        }

        public IndexModel(ILogger<IndexModel> logger, FBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        { }
        public async Task<IActionResult> OnPost()
        {
            if (Int32.TryParse(FizzBuzzResult.NumberStr, out int temp))
            {
                FizzBuzzResult.Number = temp;
                if (FizzBuzzResult.Number >= 1 && FizzBuzzResult.Number <= 1000)
                {
                    if (FizzBuzzResult.Number % 3 == 0 && FizzBuzzResult.Number % 5 == 0)
                        FizzBuzzResult.Wynik = "FizzBuzz";
                    else if (FizzBuzzResult.Number % 3 == 0)
                        FizzBuzzResult.Wynik = "Fizz";
                    else if (FizzBuzzResult.Number % 5 == 0)
                        FizzBuzzResult.Wynik = "Buzz";
                    else FizzBuzzResult.Wynik = "None";

                    FizzBuzzResult.Czas = DateTime.Now;
                    //FizzBuzzResult.OwnerId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    FizzBuzzResult.IdOwn = User.Identity.Name;
                    HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzzResult));
                    if (ModelState.IsValid)
                    {
                        await _context.FizzBuzz.AddAsync(FizzBuzzResult);
                        await _context.SaveChangesAsync();
                        return Page();
                    }
                }
                else { FizzBuzzResult.Wynik = "Error"; }
            }
            else { FizzBuzzResult.Wynik = "Error"; }
            return Page();
        }
    }
}