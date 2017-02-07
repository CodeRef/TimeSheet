using System;

using Xunit;

namespace RestMeet.Test
{

    public class MailTest
    {
        [Fact]
        public void SendMail()
        {
            Assert.True(MailDelivery.Send("jonh.ctrl@gmail.com", "wut@globalitworld.com", "test", "test"));
        }
    }
}
