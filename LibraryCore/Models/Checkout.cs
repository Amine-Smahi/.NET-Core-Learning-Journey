using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryCore.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }
        public LibraryCard LibraryCard { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }

    }
}