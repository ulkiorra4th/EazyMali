namespace MailChecker.Content.Data;

internal interface IHtmlParser
{
    public (string, string) Parse(string filePath);
}