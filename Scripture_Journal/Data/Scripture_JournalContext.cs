using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace Scripture_Journal.Models
{
    public class Scripture_JournalContext : DbContext
    {
        public Scripture_JournalContext (DbContextOptions<Scripture_JournalContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMovie.Models.Scripture> Scripture { get; set; }
    }
}
