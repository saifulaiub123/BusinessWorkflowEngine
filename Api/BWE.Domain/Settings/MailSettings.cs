using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWE.Domain.Settings
{
    public class MailSettings
    {
        public string Sender { get; set; }
        public string Title { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool SSL { get; set; }
    }
}
