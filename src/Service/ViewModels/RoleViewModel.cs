using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Service.ViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }
}