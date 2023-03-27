using MimeKit;

namespace BWE.Domain.Model
{
    public class EmailMessageModel
    {
        public MailboxAddress Sender { get; set; }
        public MailboxAddress Reciever { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
