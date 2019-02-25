using System.ComponentModel.DataAnnotations;

namespace LibraryCore.Models
{
    public class Video : LibraryAsset
    {
         [Required]
         public string Director { get; set; }
    }
}