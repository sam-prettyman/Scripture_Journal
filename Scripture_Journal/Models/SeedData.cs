using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Scripture_Journal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Scripture_JournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Scripture_JournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new RazorPagesMovie.Models.Scripture
                    {
                        Collection = "New Testament",
                        Book = "Matthew",
                        Chapter = 7,
                        Verse = 7,
                        Notes = "Knock and it will open"
                    },
                    new RazorPagesMovie.Models.Scripture
                    {
                        Collection = "Book of Mormon",
                        Book = "Mornoni",
                        Chapter = 10,
                        Verse = 2,
                        Notes = "WOW, I CAN ADD NOTES"
                    },
                    new RazorPagesMovie.Models.Scripture
                    {
                        Collection = "Book of Mormon",
                        Book = "Mornoni",
                        Chapter = 12,
                        Verse = 5,
                        Notes = "This is SPARTA "
                    }
                );
                context.SaveChanges();
            }
        }
    }
}