using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using Scripture_Journal.Models;

namespace Scripture_Journal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly Scripture_Journal.Models.Scripture_JournalContext _context;

        public IndexModel(Scripture_Journal.Models.Scripture_JournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBooks { get; set; }
        public string SortBy { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> BookQuery = from s in _context.Scripture
                                           orderby s.Book
                                           select s.Book;


            var scriptures = from m in _context.Scripture
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
                scriptures = scriptures.OrderBy(b => b.Book);

            }


            if (!string.IsNullOrEmpty(ScriptureBooks))
            {
                scriptures = scriptures.Where(x => x.Book == ScriptureBooks);

            }

            if(!string.IsNullOrEmpty(SortBy))
            {
                
                scriptures = scriptures.OrderBy(e => e.EntryDate);
                scriptures = scriptures.OrderBy(b => b.Book);
            }
          
            scriptures = scriptures.OrderBy(e => e.EntryDate);
            scriptures = scriptures.OrderBy(b => b.Book);
            
            Books = new SelectList(await BookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();
        }
    }
}
