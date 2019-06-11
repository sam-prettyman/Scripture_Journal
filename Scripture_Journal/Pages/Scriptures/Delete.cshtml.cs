using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Scripture_Journal.Models;

namespace Scripture_Journal.Pages.Scriptures
{
    public class DeleteModel : PageModel
    {
        private readonly Scripture_Journal.Models.Scripture_JournalContext _context;

        public DeleteModel(Scripture_Journal.Models.Scripture_JournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Scripture Scripture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
    {
                Scripture = await _context.Scripture.FirstOrDefaultAsync();
    }
    else
    {
                Scripture = await _context.Scripture.FirstOrDefaultAsync(m => m.ID == id);
    }

    if (Scripture == null)
    {
        return NotFound();
    }
    return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Scripture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Scripture.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Scripture.Any(e => e.ID == id);
        }
    }
}
