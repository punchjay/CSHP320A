using System.ComponentModel.DataAnnotations;

namespace homework06.Models
{
    public class Card
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string From { get; set; }
        [Required(ErrorMessage = "Please enter your birthday person")]
        public string To { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
    }
}
