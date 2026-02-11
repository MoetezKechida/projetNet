using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using projetNet.Constants;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

/// <summary>
/// Service responsible for sending emails.
/// Follows Single Responsibility Principle - only handles email sending, not template generation.
/// </summary>
public class EmailService : IEmailService
{
    private readonly IFluentEmail _fluentEmail;
    private readonly IEmailTemplateService _templateService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<EmailService> _logger;

    public EmailService(
        IFluentEmail fluentEmail,
        IEmailTemplateService templateService,
        IConfiguration configuration,
        ILogger<EmailService> logger)
    {
        _fluentEmail = fluentEmail;
        _templateService = templateService;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SendVerificationEmailAsync(string email, string token, string firstName)
    {
        var appUrl = _configuration["AppUrl"] ?? "http://localhost:5000";
        var verificationUrl = $"{appUrl}/verify-email?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}";

        var htmlBody = _templateService.GetVerificationEmailTemplate(firstName, verificationUrl);

        try
        {
            var response = await _fluentEmail
                .To(email)
                .Subject(EmailConstants.Subjects.VerifyEmail)
                .Body(htmlBody, isHtml: true)
                .SendAsync();

            if (!response.Successful)
            {
                _logger.LogError("Failed to send verification email to {Email}. Errors: {Errors}", 
                    email, string.Join(", ", response.ErrorMessages));
                throw new InvalidOperationException($"Failed to send email: {string.Join(", ", response.ErrorMessages)}");
            }

            _logger.LogInformation("Verification email sent successfully to {Email}", email);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception while sending verification email to {Email}", email);
            throw;
        }
    }

    public async Task SendPasswordResetEmailAsync(string email, string token, string firstName)
    {
        var appUrl = _configuration["AppUrl"] ?? "http://localhost:5000";
        var resetUrl = $"{appUrl}/reset-password?email={Uri.EscapeDataString(email)}&token={Uri.EscapeDataString(token)}";

        var htmlBody = _templateService.GetPasswordResetEmailTemplate(firstName, resetUrl);

        try
        {
            var response = await _fluentEmail
                .To(email)
                .Subject(EmailConstants.Subjects.ResetPassword)
                .Body(htmlBody, isHtml: true)
                .SendAsync();

            if (!response.Successful)
            {
                _logger.LogError("Failed to send password reset email to {Email}. Errors: {Errors}", 
                    email, string.Join(", ", response.ErrorMessages));
                throw new InvalidOperationException($"Failed to send email: {string.Join(", ", response.ErrorMessages)}");
            }

            _logger.LogInformation("Password reset email sent successfully to {Email}", email);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception while sending password reset email to {Email}", email);
            throw;
        }
    }
}
