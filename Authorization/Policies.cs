namespace projetNet.Authorization;

public static class Policies
{
    public const string RequireBuyer = "RequireBuyer";
    public const string RequireSeller = "RequireSeller";
    public const string RequireInspector = "RequireInspector";
    public const string RequireAdmin = "RequireAdmin";
    public const string RequireVerifiedSeller = "RequireVerifiedSeller";
}
