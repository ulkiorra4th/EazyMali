using System.Net;
using System.Net.Mail;
using MailChecker.Content;

namespace MailChecker.Net;

public class MailSender : IMailSender
{
    private readonly MailAddress _fromAddress;
    private readonly string _fromMailPassword;
    
    private string _smtpHost;
    private int _smtpPort;
    
    public MailSender(MailAddress fromAddress, string fromMailPassword)
    {
        _fromAddress = fromAddress;
        _fromMailPassword = fromMailPassword;
    }

    public MailSender(MailAddress fromAddress, string fromMailPassword, string smtpHost, int smtpPort) :
        this(fromAddress, fromMailPassword)
    {
        ConfigureSmtp(smtpHost, smtpPort);
    }
    
    public void ConfigureSmtp(string host, int port)
    {
        _smtpHost = host;
        _smtpPort = port;
    }

    public async Task SendMail(MailAddress to, MailContent content)
    {
        var message = new MailMessage(_fromAddress, to)
        {
            Subject = content.Subject,
            Body = content.Body,
            IsBodyHtml = content.IsBodyHtml
        };
        
        using (var smtp = new SmtpClient(_smtpHost, _smtpPort))
        {
            smtp.Credentials = new NetworkCredential(_fromAddress.Address, _fromMailPassword);
            smtp.EnableSsl = true;
            
            await smtp.SendMailAsync(message);
        }
    }
}