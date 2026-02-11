using Microsoft.AspNetCore.Identity.UI.Services;

namespace projetNet.Services.Services;

public class NoOpEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // For development: Just log instead of actually sending email
        Console.WriteLine($"Email to {email}: {subject}");
        return Task.CompletedTask;
    }
}
