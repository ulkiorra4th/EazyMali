using System.Net.Mail;
using System.Text;
using MailChecker.Content;
using MailChecker.Net;

namespace MailChecker.Tests;

public class MailSenderTest
{
    private readonly MailContent _content;
    private readonly IMailSender _mailSender;

    public MailSenderTest()
    {
        List<string> colors = new List<string> { "red", "green", "pink", 
            "purple", "blue", "yellow", 
            "black", "brown", "cyan"};
        StringBuilder sb = new();

        int size = 57;
        foreach (var color in colors)
        { 
            sb.Append($"<h1 style=\"color: {color} ; font-size: {size}px\">WWWW</h1>"); 
            size-=3;
        }

        IMailContentBuilder contentBuilder = new MailContentBuilder();
        
        _content = contentBuilder.BuildMailContent("МАСАНЯ", "Если перейти по этой ссылке, то ты увидишь <a href=^>красавицу мою любимую</a>", "https://vk.com/annnk_lk", true);
        _mailSender = new MailSender(new MailAddress("ramin.muhtarov@gmail.com", "ЛОХ"), "icue xxkz rbib ntso", "smtp.gmail.com", 587);
    }
    
    [Fact]
    public void Test1()
    {
        _mailSender.SendMailAsync(new MailAddress("ann1405gr@gmail.com"), _content);
    }
}