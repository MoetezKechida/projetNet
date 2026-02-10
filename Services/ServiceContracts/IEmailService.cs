using projetNet.Models;

namespace projetNet.Services.ServiceContracts;

public interface IEmailService
{
    Task SendVerificationEmailAsync(string email, string token, string firstName);
    Task SendPasswordResetEmailAsync(string email, string token, string firstName);
}