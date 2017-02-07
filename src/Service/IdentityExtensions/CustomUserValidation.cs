using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TimeTracker.Model;

namespace TimeTracker.Service.IdentityExtensions
{
    public class CustomUserValidation : IIdentityValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(ApplicationUser item)
        {
            if (item.UserName.ToLower().Contains("bad"))
                return Task.FromResult(IdentityResult.Failed("UserName cannot contain bad"));
            //if (item.HomeTown.ToLower().Contains("unknown"))
            //    return Task.FromResult(IdentityResult.Failed("HomeTown cannot contain unknown city"));
            return Task.FromResult(IdentityResult.Success);
        }
    }

    public class MyPasswordValidation : IIdentityValidator<string>
    {
        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (item.ToLower().Contains("111111"))
                return Task.FromResult(IdentityResult.Failed("Password Cannot contain 6 consecutive digits"));
            return Task.FromResult(IdentityResult.Success);
        }
    }

    // This allows you to Hash a given password using your own Hashing system
    // Note be very careful when plugging in your own Hasher as there are no gurantees that it will be safe.
    // The reason this hook is here so you can migrate easily from earlier membership systems which
    // might be using a different Hashing mechanism
    public class MyPasswordHasher : IPasswordHasher
    {
        // If input password is foo then in the database it will be footestpranav
        public string HashPassword(string password)
        {
            return password + "testpranav";
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == providedPassword + "testpranav")
                return PasswordVerificationResult.Success;
            return PasswordVerificationResult.Failed;
        }
    }
}