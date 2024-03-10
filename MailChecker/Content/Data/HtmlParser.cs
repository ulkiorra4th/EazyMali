using System.Text;

namespace MailChecker.Content.Data;

public class HtmlParser : IHtmlParser
{
    public (string, string) Parse(string filePath)
    {
        if (!File.Exists(filePath)) throw new FileNotFoundException();

        using (var sr = new StreamReader(filePath, Encoding.UTF8))
        {
            string content = sr.ReadToEnd();
            var splittedContent = content.Split("---", StringSplitOptions.RemoveEmptyEntries);

            if (splittedContent.Length != 2) 
                throw new InvalidDataException("Header or body has not found in file");

            string subject = splittedContent[0];
            string body = splittedContent[1];

            return (subject, body);
        }
    }
}