using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMovie.Models;
using Scripture_Journal.Models;

namespace Scripture_Journal.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly Scripture_Journal.Models.Scripture_JournalContext _context;

        public CreateModel(Scripture_Journal.Models.Scripture_JournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scripture Scripture { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}