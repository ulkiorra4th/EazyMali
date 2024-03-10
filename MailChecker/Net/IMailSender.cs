using System.Net.Mail;
using MailChecker.Content;

namespace MailChecker.Net;

public interface IMailSender
{
    public void ConfigureSmtp(string host, int port);
    public Task SendMailAsync(MailAddress to, MailContent content);
}