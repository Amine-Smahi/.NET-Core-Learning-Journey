using System.ComponentModel.DataAnnotations;

namespace PushNotificationCore.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must fill the input")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Its an exception")]
        public bool SimularException { get; set; }
    }
}
