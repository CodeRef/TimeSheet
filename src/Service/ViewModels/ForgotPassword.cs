using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Service.ViewModels
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}