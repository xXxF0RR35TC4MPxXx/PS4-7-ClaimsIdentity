using PS4_7_ClaimsIdentity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS4_7_ClaimsIdentity.Data
{
    public class FBContext : DbContext
    {
        public FBContext(DbContextOptions options) : base(options) { }
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}