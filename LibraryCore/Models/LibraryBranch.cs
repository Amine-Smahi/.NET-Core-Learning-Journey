using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryCore.Models
{
    public class LibraryBranch
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }

        public string ImageUrl { get; set; }
    }
}