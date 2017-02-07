using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RestMeet
{
    public class MailDelivery
    {
        private string _from;
        private string _to;
        private string _subject;
        private string _body;

        public MailDelivery(string from, string to, string subject, string body)
        {
            _from = from;
            _to = to;
            _subject = subject;
            _body = body;
        }

        public async Task<bool> Send()
        {
            try
            {
                var message = new MailMessage(_from, _to, _subject, _body);
                message.IsBodyHtml = true;
                var client = new SmtpClient();
                await client.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}