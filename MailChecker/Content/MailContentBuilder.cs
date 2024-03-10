using System.Text;
using MailChecker.Content.Data;

namespace MailChecker.Content;

public class MailContentBuilder : IMailContentBuilder
{
    private readonly IHtmlParser _htmlParser;
    
    public char InsertLinkSymbol { get; set; }

    public MailContentBuilder()
    {
        _htmlParser = new HtmlParser();
        InsertLinkSymbol = '^';
    }
    
    public MailContentBuilder(char insertLinkSymbol)
    {
        _htmlParser = new HtmlParser();
        InsertLinkSymbol = insertLinkSymbol;
    }
    
    public MailContent BuildMailContent(string subject, string body, string confirmationLink, bool isBodyHtml = false)
    {
        body = InsertConfirmLinkToBody(confirmationLink, body);
        
        return new MailContent(subject, body, isBodyHtml);
    }
    
    public MailContent BuildMailContentFromHtml(string htmlFilePath, string confirmationLink)
    {
        var (subject, body) = _htmlParser.Parse(htmlFilePath);
        body = InsertConfirmLinkToBody(confirmationLink, body);
        
        return new MailContent(subject, body, isBodyHtml: true);
    }
    
    private string InsertConfirmLinkToBody(string confirmationLink, string body)
    {
        int insertSymbolIndex = body.IndexOf(InsertLinkSymbol);
        if (insertSymbolIndex == -1) throw new InvalidDataException("Insert link symbol has not found");
        
        var sb = new StringBuilder(body);
        
        sb.Insert(insertSymbolIndex + 1, $"\"{confirmationLink}\"");
        sb.Remove(insertSymbolIndex, 1);

        return sb.ToString();
    }
}