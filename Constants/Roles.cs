namespace projetNet.Constants;

/// <summary>
/// Centralized role name constants to avoid magic strings throughout the codebase.
/// Provides compile-time safety and single source of truth for role names.
/// </summary>
public static class Roles
{
    /// <summary>
    /// Buyer role - Regular users who can view and purchase vehicles
    /// </summary>
    public const string Buyer = "Buyer";
    
    /// <summary>
    /// Seller role - Users who can list and manage vehicle sales
    /// </summary>
    public const string Seller = "Seller";
    
    /// <summary>
    /// Inspector role - Authorized vehicle inspectors
    /// </summary>
    public const string Inspector = "Inspector";
    
    /// <summary>
    /// Admin role - System administrators with full access
    /// </summary>
    public const string Admin = "Admin";
    
    /// <summary>
    /// All available roles in the system
    /// </summary>
    public static readonly string[] All = { Buyer, Seller, Inspector, Admin };
    
    /// <summary>
    /// Roles that users can self-register as
    /// </summary>
    public static readonly string[] Registerable = { Buyer, Seller };
}
