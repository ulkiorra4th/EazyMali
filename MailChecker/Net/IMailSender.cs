using System.Net.Mail;
using MailChecker.Content;

namespace MailChecker.Net;

public interface IMailSender
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="senderAddress"></param>
    /// <param name="displayName"></param>
    /// <param name="senderMailPassword"></param>
    /// <param name="host"></param>
    /// <param name="port"></param>
    public void ConfigureSender(string senderAddress, string displayName, string senderMailPassword, string host,
        int port);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="senderAddress"></param>
    /// <param name="displayName"></param>
    /// <param name="senderMailPassword"></param>
    public void SetSenderAddress(string senderAddress, string displayName, string senderMailPassword);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="senderMailPassword"></param>
    public void SetSenderAddress(MailAddress sender, string senderMailPassword);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="host"></param>
    /// <param name="port"></param>
    public void ConfigureSmtp(string host, int port);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="receiver"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public Task SendMailAsync(MailAddress receiver, MailContent content);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="receiverMailAddress"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public Task SendMailAsync(string receiverMailAddress, MailContent content);
}