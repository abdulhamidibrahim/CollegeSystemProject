using MimeKit;

namespace User.Management.Services.Models;

public class Message
{

    public List<MailboxAddress> To { get; set; } = new List<MailboxAddress>();
    public string Subject { get; set; }
    public string Content { get; set; }

    public Message(IEnumerable<string> messageTo, string messageSubject, string messageContent)
    {
        To.AddRange(messageTo.Select(x => new MailboxAddress("Email", x)));
        Subject = messageSubject;
        Content = messageContent;
    }
}