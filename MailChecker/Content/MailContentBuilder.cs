using System.Data;
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
    
    public MailContent BuildMailContent(string subject, string body, string confirmLink, bool isBodyHtml = false)
    {
        body = InsertConfirmLinkToBody(confirmLink, body);
        
        return new MailContent(subject, body, isBodyHtml);
    }

    public MailContent BuildMailContentFromHtml(string htmlFilePath, string confirmLink)
    {
        var (subject, body) = _htmlParser.Parse(htmlFilePath);
        body = InsertConfirmLinkToBody(confirmLink, body);
        
        return new MailContent(subject, body, isBodyHtml: true);
    }
    
    private string InsertConfirmLinkToBody(string confirmLink, string body)
    {
        int insertSymbolIndex = body.IndexOf(InsertLinkSymbol);
        if (insertSymbolIndex == -1) throw new DataException("Insert link symbol has not found");
        
        var sb = new StringBuilder(body);
        
        sb.Insert(insertSymbolIndex + 1, $"\"{confirmLink}\"");
        sb.Remove(insertSymbolIndex, 1);

        return sb.ToString();
    }
}