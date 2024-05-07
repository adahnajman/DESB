using System.ComponentModel.DataAnnotations;

namespace Exercise.Models.ViewModel
{
    public class UserVM
    {
        [Required(ErrorMessage = "Required Text")]
        public string? UserName { get; set; }
        public string? userFullName { get; set; }

        [Required(ErrorMessage = "Required Text")]
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
