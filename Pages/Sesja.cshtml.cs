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
    public class SesjaModel : PageModel
    {
        private readonly ILogger<SesjaModel> _logger;

        
        public SesjaModel(ILogger<SesjaModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public FizzBuzz FizzBuzzResult { get; set; }
        public void OnGet()
        {
            var SessionValue = HttpContext.Session.GetString("SessionAddress");
            if (SessionValue != null)
                FizzBuzzResult = JsonConvert.DeserializeObject<FizzBuzz>(SessionValue);
        }

    }
}
