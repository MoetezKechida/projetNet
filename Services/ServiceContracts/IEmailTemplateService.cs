namespace projetNet.Services.ServiceContracts;

/// <summary>
/// Service for generating email templates.
/// Separates template generation logic from email sending logic (Single Responsibility Principle).
/// </summary>
public interface IEmailTemplateService
{
    /// <summary>
    /// Generates HTML template for email verification
    /// </summary>
    /// <param name="firstName">User's first name</param>
    /// <param name="verificationUrl">URL for email verification</param>
    /// <returns>HTML email body</returns>
    string GetVerificationEmailTemplate(string firstName, string verificationUrl);
    
    /// <summary>
    /// Generates HTML template for password reset
    /// </summary>
    /// <param name="firstName">User's first name</param>
    /// <param name="resetUrl">URL for password reset</param>
    /// <returns>HTML email body</returns>
    string GetPasswordResetEmailTemplate(string firstName, string resetUrl);
}
