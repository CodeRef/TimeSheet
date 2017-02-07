using System;
using System.Net.Mail;

namespace RestMeet
{
    public class MailDelivery
    {
        public static bool Send(string from, string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage(from, to, subject, body);
                message.IsBodyHtml = true;
                var client = new SmtpClient();
                client.Send(message);

                //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                //var message = new MailMessage();
                //message.To.Add(new MailAddress("wut@globalitworld.com")); //replace with valid value
                //message.Subject = "Your email subject";
                //message.Body = string.Format(body, "jonh", "Jonh.ctrl", "test");
                //message.IsBodyHtml = true;


                //var m = new MailMessage(new MailAddress("wut@globalitworld.com", "Web Registration"), new MailAddress("wut@globalitworld.com"));
                //m.Subject = "Email confirmation";
                //m.Body = "test";//string.Format("Dear {0}<BR/>Thank you for your registration, please click on the below link to comlete your registration: <a href=\"{1}\" title=\"User Email Confirm\">{1}</a>", user.UserName, Url.Action("ConfirmEmail", "Account", new { Token = user.Id, Email = user.Email }, Request.Url.Scheme));

                //m.IsBodyHtml = true;
                
                //SmtpClient smtp = new SmtpClient();
                //smtp.Send(m); 
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}