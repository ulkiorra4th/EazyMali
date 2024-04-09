using MailChecker.Content;
using MailChecker.Net;
using Microsoft.Extensions.DependencyInjection;

namespace MailChecker;

public static class MailCheckerServiceCollectionExtensions
{
    public static IServiceCollection AddMailChecker(this IServiceCollection services)
    {
        services.AddSingleton<IMailContentBuilder, MailContentBuilder>();
        services.AddSingleton<IMailSender, MailSender>();

        return services;
    }
}