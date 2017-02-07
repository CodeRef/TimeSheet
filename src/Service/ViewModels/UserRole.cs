using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeTracker.Model;

namespace TimeTracker.Service.ViewModels
{
    public class UserRole
    {
        public ApplicationUser User { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }

    public class RoleUser
    {
        public IdentityRole Role { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}