﻿using System.Web.Mvc;

namespace TimeSheet.Areas.UserProfile
{
    public class UserProfileAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserProfile";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserProfile_default",
                "UserProfile/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                 new[] { "TimeSheet.Areas.UserProfile.Controllers" }
            );
        }
    }
}