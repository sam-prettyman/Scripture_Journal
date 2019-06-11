using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Scripture 
    {
        public int ID { get; set; }
        [StringLength(100, MinimumLength = 0)]
        public string Collection { get; set; }

        [StringLength(60, MinimumLength = 0)]
        public string Book { get; set; }
        
        public int Chapter { get; set; }
        public int Verse { get; set; }

        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        
        public string Notes { get; set; }

      
        
    }
}

