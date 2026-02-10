namespace projetNet.Constants;

/// <summary>
/// Email-related constants for subjects, expiry times, and other email configuration
/// </summary>
public static class EmailConstants
{
    /// <summary>
    /// Email subject lines
    /// </summary>
    public static class Subjects
    {
        public const string VerifyEmail = "Verify Your Email Address";
        public const string ResetPassword = "Reset Your Password";
    }
    
    /// <summary>
    /// Token expiry durations (human-readable)
    /// </summary>
    public static class Expiry
    {
        public const string EmailVerification = "24 hours";
        public const string PasswordReset = "1 hour";
    }
    
    /// <summary>
    /// Email styling colors
    /// </summary>
    public static class Colors
    {
        public const string Primary = "#007bff";
        public const string Danger = "#dc3545";
        public const string TextPrimary = "#333";
        public const string TextSecondary = "#666";
    }
}
