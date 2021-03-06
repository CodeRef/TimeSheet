﻿using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TimeTracker.Service.IdentityExtensions
{
    public class CustomClaimsIdentityFactory<TUser> : ClaimsIdentityFactory<TUser> where TUser : class, IUser<string>
    {
        internal const string IdentityProviderClaimType =
            "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";

        internal const string DefaultIdentityProviderClaimValue = "ASP.NET Identity";

        public CustomClaimsIdentityFactory()
        {
            UserIdClaimType = ClaimTypes.NameIdentifier;
            UserNameClaimType = ClaimsIdentity.DefaultNameClaimType;
            // This is the custom claim added to the User. This can keep track of the
            // last login time of the User
            LastLoginTimeType = "LoginTime";
        }

        public new string UserIdClaimType { get; set; }
        public new string UserNameClaimType { get; set; }
        public string LastLoginTimeType { get; set; }

        public override async Task<ClaimsIdentity> CreateAsync(UserManager<TUser, string> manager, TUser user,
            string authenticationType)
        {
            // This is a standard place where you can register your ClaimsIdentityFactory.
            // This class generates a ClaimsIdentity for the given user
            // By default it adds Roles, UserName, UserId as Claims for the User
            // You can add more standard set of claims here if you want to.
            // The Following sample shows how you can add more claims in a centralized way.
            // This sample does not add Roles as Claims

            var id = new ClaimsIdentity(authenticationType, UserNameClaimType, null);
            id.AddClaim(new Claim(UserIdClaimType, user.Id, ClaimValueTypes.String));
            id.AddClaim(new Claim(UserNameClaimType, user.UserName, ClaimValueTypes.String));
            id.AddClaim(new Claim(IdentityProviderClaimType, DefaultIdentityProviderClaimValue, ClaimValueTypes.String));

            // Add the claims for the login time
            id.AddClaim(new Claim(LastLoginTimeType, DateTime.Now.ToString(CultureInfo.InvariantCulture)));

            if (manager.SupportsUserClaim)
                id.AddClaims(await manager.GetClaimsAsync(user.Id));
            return id;
        }
    }
}