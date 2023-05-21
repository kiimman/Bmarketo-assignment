using Microsoft.Build.Framework;

namespace webbmvcapp.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }
        [Required]
        public string? Message { get; set; }
    }
}
