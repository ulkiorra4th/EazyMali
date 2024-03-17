using System.Net.Mail;
using MailChecker.Content;

namespace MailChecker.Net;

public interface IMailSender
{
    public void ConfigureSender(string senderAddress, string displayName, string senderMailPassword, string host,
        int port);
    public void SetSenderAddress(string senderAddress, string displayName, string senderMailPassword);
    public void SetSenderAddress(MailAddress sender, string senderMailPassword);
    public void ConfigureSmtp(string host, int port);
    public Task SendMailAsync(MailAddress receiver, MailContent content);
    public Task SendMailAsync(string receiverMailAddress, MailContent content);
}