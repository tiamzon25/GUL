using GUL.Shared.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Point.Of.Sale.Registrations;

public static class EmailRegistration
{
    public static void AddEmailRegistration(this IServiceCollection services, Smtp smtp)
    {
        services.AddFluentEmail(smtp.Sender)
            .AddSmtpSender(smtp.Host,
                smtp.Port,
                smtp.UserName,
                smtp.Password);
    }
}
