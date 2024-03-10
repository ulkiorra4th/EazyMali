namespace MailChecker.Content.Data;

public interface IHtmlParser
{
    public (string, string) Parse(string filePath);
}