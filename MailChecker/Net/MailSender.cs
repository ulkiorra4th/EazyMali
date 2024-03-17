using System.Data;
using System.Net;
using System.Net.Mail;
using MailChecker.Content;

namespace MailChecker.Net;

public class MailSender : IMailSender
{
    private MailAddress? _sender;
    private string? _senderMailPassword;
    
    private string? _smtpHost;
    private int _smtpPort;
    
    public MailSender() { }
    
    public MailSender(MailAddress sender, string senderMailPassword)
    {
        _sender = sender;
        _senderMailPassword = senderMailPassword;
    }

    public MailSender(MailAddress sender, string senderMailPassword, string smtpHost, int smtpPort) :
        this(sender, senderMailPassword)
    {
        ConfigureSmtp(smtpHost, smtpPort);
    }

    public MailSender(string senderAddress, string displayName, string senderMailPassword) 
        : this(new MailAddress(senderAddress, displayName), senderMailPassword)
    { }
    
    public MailSender(string senderAddress, string displayName, string senderMailPassword, string smtpHost, int smtpPort) 
        : this(new MailAddress(senderAddress, displayName), senderMailPassword, smtpHost, smtpPort)
    { }

    public void ConfigureSender(string senderAddress, string displayName, string senderMailPassword, string host, 
        int port)
    {
        SetSenderAddress(senderAddress, displayName, senderMailPassword);
        ConfigureSmtp(host, port);
    }

    public void SetSenderAddress(string senderAddress, string displayName, string senderMailPassword)
    {
        SetSenderAddress(new MailAddress(senderAddress, displayName), senderMailPassword);
    }

    public void SetSenderAddress(MailAddress sender, string senderMailPassword)
    {
        _sender = sender;
        _senderMailPassword = senderMailPassword;
    }
    
    public void ConfigureSmtp(string host, int port)
    {
        _smtpHost = host;
        _smtpPort = port;
    }
    
    public async Task SendMailAsync(MailAddress receiver, MailContent content)
    {
        var message = new MailMessage(_sender ?? throw new DataException("Sender is null"), receiver)
        {
            Subject = content.Subject,
            Body = content.Body,
            IsBodyHtml = content.IsBodyHtml
        };
        
        using (var smtp = new SmtpClient(_smtpHost, _smtpPort))
        {
            smtp.Credentials = new NetworkCredential(_sender.Address, _senderMailPassword);
            smtp.EnableSsl = true;
            
            await smtp.SendMailAsync(message);
        }
    }

    public async Task SendMailAsync(string receiverMailAddress, MailContent content)
    {
        await SendMailAsync(new MailAddress(receiverMailAddress), content);
    }
}