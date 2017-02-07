using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Service.ViewModels
{
    public class ExternalLoginConfirmation
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        public string LoginProvider { get; set; }
    }
}