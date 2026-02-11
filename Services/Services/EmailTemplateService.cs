using projetNet.Constants;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

/// <summary>
/// Service responsible for generating email HTML templates.
/// Follows Single Responsibility Principle by separating template generation from email sending.
/// </summary>
public class EmailTemplateService : IEmailTemplateService
{
    public string GetVerificationEmailTemplate(string firstName, string verificationUrl)
    {
        return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: {EmailConstants.Colors.TextPrimary}; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                    .button {{ 
                        display: inline-block; 
                        padding: 12px 24px; 
                        background-color: {EmailConstants.Colors.Primary}; 
                        color: white; 
                        text-decoration: none; 
                        border-radius: 4px; 
                        margin: 20px 0;
                    }}
                    .footer {{ margin-top: 30px; font-size: 12px; color: {EmailConstants.Colors.TextSecondary}; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h2>Hello {firstName},</h2>
                    <p>Thank you for registering! Please verify your email address to complete your registration.</p>
                    <a href='{verificationUrl}' class='button'>Verify Email Address</a>
                    <p>Or copy and paste this link into your browser:</p>
                    <p style='word-break: break-all;'>{verificationUrl}</p>
                    <div class='footer'>
                        <p>This link will expire in {EmailConstants.Expiry.EmailVerification}.</p>
                        <p>If you didn't create an account, please ignore this email.</p>
                    </div>
                </div>
            </body>
            </html>
        ";
    }

    public string GetPasswordResetEmailTemplate(string firstName, string resetUrl)
    {
        return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    body {{ font-family: Arial, sans-serif; line-height: 1.6; color: {EmailConstants.Colors.TextPrimary}; }}
                    .container {{ max-width: 600px; margin: 0 auto; padding: 20px; }}
                    .button {{ 
                        display: inline-block; 
                        padding: 12px 24px; 
                        background-color: {EmailConstants.Colors.Danger}; 
                        color: white; 
                        text-decoration: none; 
                        border-radius: 4px; 
                        margin: 20px 0;
                    }}
                    .footer {{ margin-top: 30px; font-size: 12px; color: {EmailConstants.Colors.TextSecondary}; }}
                </style>
            </head>
            <body>
                <div class='container'>
                    <h2>Hello {firstName},</h2>
                    <p>We received a request to reset your password.</p>
                    <a href='{resetUrl}' class='button'>Reset Password</a>
                    <p>Or copy and paste this link into your browser:</p>
                    <p style='word-break: break-all;'>{resetUrl}</p>
                    <div class='footer'>
                        <p>This link will expire in {EmailConstants.Expiry.PasswordReset}.</p>
                        <p>If you didn't request a password reset, please ignore this email.</p>
                    </div>
                </div>
            </body>
            </html>
        ";
    }
}
