namespace projetNet.Services.ServiceContracts;

public interface IChatAssistantService
{
    Task<string> GetResponseAsync(string userMessage, string? userId = null);
}
