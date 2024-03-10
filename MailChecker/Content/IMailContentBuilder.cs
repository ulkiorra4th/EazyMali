namespace MailChecker.Content;

public interface IMailContentBuilder
{
    public MailContent BuildMailContent(string subject, string body, string confirmLink, bool isBodyHtml = false);
    public MailContent BuildMailContentFromHtml(string htmlFilePath, string confirmLink);
}