using System;
using System.IdentityModel.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using TimeTracker.Model;
using TimeTracker.Service.ViewModels;

namespace TimeTracker.Api.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(Register userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await validateEmail(userModel.Email))
            {
                var uname = await getUserName(userModel.UserName);
                var user = new ApplicationUser
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = uname,
                    Email = userModel.Email
                };
                // Store Gender as Claim
                user.Claims.Add(new IdentityUserClaim
                {
                    ClaimType = ClaimTypes.Gender,
                    ClaimValue = "Male",
                    UserId = user.Id
                });
                var result = await AppUserManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    AppUserManager.AddToRole(user.Id, "User");
                    await sendComfirmEmail(user, userModel.UserName);
                    return Ok();
                }
                var errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }
                ;
            }
            //else
            //{
            //    // notify user that the email has already register.
            //}
            return Ok();
        }

        /// <summary>
        ///     Check incoming email has already in data base. If it is, send recovery password email to user and notify user to
        ///     check their email.
        /// </summary>
        /// <returns></returns>
        private async Task<bool> validateEmail(string email)
        {
            var user = await AppUserManager.FindByEmailAsync(email);
            if (user == null)
            {
                return true;
            }
            await forgotPasswordEmail(user);
            return false;
        }

        private async Task<bool> forgotPasswordEmail(ApplicationUser user)
        {
            var provider = new DpapiDataProtectionProvider("SiamMarket");
            AppUserManager.UserTokenProvider =
                new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));

            var code = await AppUserManager.GeneratePasswordResetTokenAsync(user.Id);
            var callbackUrl = "http://localhost:45258/backend/account/resetpassword?userId=" + user.Id + "&code=" + code;
            ;
            //Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
            // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
            return
                await
                    new MailDelivery("jonh.ctrl@gmail.com", user.Email, "Reset Password",
                        "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>").Send();
        }

        /// <summary>
        ///     If username is already have in data base, generate new random name and allow user to change it later.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private async Task<string> getUserName(string username)
        {
            var user = await AppUserManager.FindByNameAsync(username);
            if (user == null)
            {
                return username;
            }
            return username + DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        private async Task<bool> sendComfirmEmail(ApplicationUser user, string originalUsername)
        {
            try
            {
                var provider = new DpapiDataProtectionProvider("SiamMarket");
                AppUserManager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));

                var code = await AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                var callbackUrl = "http://localhost:45258/backend/account/confirmemail?userId=" + user.Id + "&code=" +
                                  code;
                // "--not-implement-yet";// Url.Action("ConfirmEmail", "Account", new { area = "Backend", userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                var mailBody = "";
                if (originalUsername.Equals(user.UserName))
                {
                    mailBody = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>";
                }
                else
                {
                    // Include link to change username. --It not for every user, just for the user which has auto generate username.
                    mailBody = "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>";
                }
                await new MailDelivery("jonh.ctrl@gmail.com", user.Email, "Confirm your account", mailBody).Send();
                return true;
            }
            catch
            {
                return true;
            }
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        //  [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await AppUserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await AppUserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    if (user != null)
                    {
                        await sendComfirmEmail(user, user.UserName);
                        // TempData["msgH1"] = user.FirstName + " " + user.LastName;
                    }
                    //TempData["msgDetail"] = user == null ? "Your email is not register on Siam-Market yet. Please <a href=\"/\" style=\"font-weight:bold;\">CLICK HERE</a> to register." : "Please check your email which is given while you register account and confirm it bofore login.";
                    //return RedirectToAction("Registered", "Home", new { area = "" });
                    return Ok();
                }
                await forgotPasswordEmail(user);
                //  return RedirectToAction("ForgotPasswordConfirmation", "Account");
                return Ok();
            }
            return Ok();
            //// If we got this far, something failed, redisplay form
            //return View(model);
        }

        //    var identity = User.Identity as System.Security.Claims.ClaimsIdentity;
        //    //Only SuperAdmin or Admin can delete users (Later when implement roles)
        //{
        //public IHttpActionResult GetUsers()
        //[Route("users")]

        //[Authorize(Roles="Admin")]

        //    return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
        //}

        //[Authorize(Roles = "Admin")]
        //[Route("user/{id:guid}", Name = "GetUserById")]
        //public async Task<IHttpActionResult> GetUser(string Id)
        //{
        //    //Only SuperAdmin or Admin can delete users (Later when implement roles)
        //    var user = await this.AppUserManager.FindByIdAsync(Id);

        //    if (user != null)
        //    {
        //        return Ok(this.TheModelFactory.Create(user));
        //    }

        //    return NotFound();

        //}

        //[Authorize(Roles = "Admin")]
        //[Route("user/{username}")]
        //public async Task<IHttpActionResult> GetUserByName(string username)
        //{
        //    //Only SuperAdmin or Admin can delete users (Later when implement roles)
        //    var user = await this.AppUserManager.FindByNameAsync(username);

        //    if (user != null)
        //    {
        //        return Ok(this.TheModelFactory.Create(user));
        //    }

        //    return NotFound();

        //}

        //[AllowAnonymous]
        //[Route("create")]
        //public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new ApplicationUser()
        //    {
        //        UserName = createUserModel.Username,
        //        Email = createUserModel.Email,
        //        FirstName = createUserModel.FirstName,
        //        LastName = createUserModel.LastName//,
        //      //  Level = 3,
        //      //  JoinDate = DateTime.Now.Date,
        //    };

        //    IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);

        //    if (!addUserResult.Succeeded)
        //    {
        //        return GetErrorResult(addUserResult);
        //    }

        //    string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

        //    var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

        //    await this.AppUserManager.SendEmailAsync(user.Id,
        //                                            "Confirm your account",
        //                                            "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

        //    Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

        //    return Created(locationHeader, TheModelFactory.Create(user));

        //}

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        //public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        //{
        //    if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
        //    {
        //        ModelState.AddModelError("", "User Id and Code are required");
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

        //    if (result.Succeeded)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return GetErrorResult(result);
        //    }
        //}

        //[Authorize]
        //[Route("ChangePassword")]
        //public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //[Authorize(Roles = "Admin")]
        //[Route("user/{id:guid}")]
        //public async Task<IHttpActionResult> DeleteUser(string id)
        //{
        //    //Only SuperAdmin or Admin can delete users (Later when implement roles)

        //    var appUser = await this.AppUserManager.FindByIdAsync(id);

        //    if (appUser != null)
        //    {
        //        IdentityResult result = await this.AppUserManager.DeleteAsync(appUser);

        //        if (!result.Succeeded)
        //        {
        //            return GetErrorResult(result);
        //        }

        //        return Ok();

        //    }

        //    return NotFound();

        //}

        //[Authorize(Roles="Admin")]
        //[Route("user/{id:guid}/roles")]
        //[HttpPut]
        //public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        //{
        //    var appUser = await this.AppUserManager.FindByIdAsync(id);

        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

        //    var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

        //    if (rolesNotExists.Count() > 0) {
        //        ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

        //    if (!removeResult.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Failed to remove user roles");
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

        //    if (!addResult.Succeeded)
        //    {
        //        ModelState.AddModelError("", "Failed to add user roles");
        //        return BadRequest(ModelState);
        //    }

        //    return Ok();

        //}

        //[Authorize(Roles = "Admin")]
        //[Route("user/{id:guid}/assignclaims")]
        //[HttpPut]
        //public async Task<IHttpActionResult> AssignClaimsToUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToAssign) {
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //     var appUser = await this.AppUserManager.FindByIdAsync(id);

        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    foreach (ClaimBindingModel claimModel in claimsToAssign)
        //    {
        //        if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type)) {
        //            await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
        //        }

        //        await this.AppUserManager.AddClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
        //    }

        //    return Ok();
        //}

        //[Authorize(Roles = "Admin")]
        //[Route("user/{id:guid}/removeclaims")]
        //[HttpPut]
        //public async Task<IHttpActionResult> RemoveClaimsFromUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToRemove)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var appUser = await this.AppUserManager.FindByIdAsync(id);

        //    if (appUser == null)
        //    {
        //        return NotFound();
        //    }

        //    foreach (ClaimBindingModel claimModel in claimsToRemove)
        //    {
        //        if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
        //        {
        //            await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
        //        }
        //    }

        //    return Ok();
        //}
    }
}