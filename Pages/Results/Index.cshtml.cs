using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class IndexModel : PageModel
    {
        private readonly FBContext _context;

        public IndexModel(FBContext context)
        {
            _context = context;
        }
        public string UserName(string name)
        {
            if (!String.IsNullOrEmpty(name))
                return name.Split('@')[0];
            else return "Anonymous";
        }
        public IList<FizzBuzz> FizzBuzz { get;set; }
        public void OnGet()
        {
            FizzBuzz = _context.FizzBuzz.OrderByDescending(u => u.Czas).Take(20).ToList();
        }
    }
}
