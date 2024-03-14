using System.Net.Mail;
using MailChecker.Content;
using MailChecker.Net;

IMailContentBuilder contentBuilder = new MailContentBuilder();
var content = contentBuilder.BuildMailContentFromHtml("somefilepath", "https://somelink");

IMailSender sender = new MailSender(new MailAddress("ramin.muhtarov@gmail.com", "ЛОХ"), "icue xxkz rbib ntso", "smtp.gmail.com", 587);
sender.SendMailAsync(new MailAddress("someAddress"),content);