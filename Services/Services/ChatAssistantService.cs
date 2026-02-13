using System.ClientModel;
using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using projetNet.Services.ServiceContracts;

namespace projetNet.Services.Services;

public class ChatAssistantService : IChatAssistantService
{
    private readonly ChatClient _chatClient;
    private readonly IVehicleService _vehicleService;

    private const string SystemPrompt = """
        You are DRIVOXE Assistant, a helpful AI for a vehicle marketplace platform called DRIVOXE.
        The platform allows users to buy, rent, and sell vehicles. Users can also book test drives
        and inspections.

        Your responsibilities:
        - Help users find vehicles (recommend based on budget, type, brand preferences)
        - Explain platform features: browsing, booking, renting, buying, selling, inspections
        - Answer questions about the booking process, payment, and vehicle listings
        - Be friendly, concise, and professional
        - If asked about specific vehicle availability, suggest the user check the /cars page
        - If asked about account issues, suggest contacting support
        - Never make up vehicle data — only reference what is provided in context
        - Keep answers brief (2-4 sentences max unless detail is asked for)
        - Respond in the same language the user writes in
        """;

    public ChatAssistantService(IConfiguration configuration, IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;

        var endpoint = configuration["AzureOpenAI:Endpoint"]
            ?? throw new InvalidOperationException("AzureOpenAI:Endpoint is not configured.");
        var apiKey = configuration["AzureOpenAI:ApiKey"]
            ?? throw new InvalidOperationException("AzureOpenAI:ApiKey is not configured.");
        var deploymentName = configuration["AzureOpenAI:DeploymentName"] ?? "gpt-4o-mini";

        var azureClient = new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
        _chatClient = azureClient.GetChatClient(deploymentName);
    }

    public async Task<string> GetResponseAsync(string userMessage, string? userId = null)
    {
        var inventoryContext = await BuildInventoryContextAsync();

        var messages = new List<ChatMessage>
        {
            new SystemChatMessage($"{SystemPrompt}\n\nCurrent inventory snapshot:\n{inventoryContext}"),
            new UserChatMessage(userMessage)
        };

        var options = new ChatCompletionOptions
        {
            MaxOutputTokenCount = 300,
            Temperature = 0.7f,
        };

        ChatCompletion completion = await _chatClient.CompleteChatAsync(messages, options);

        return completion.Content[0].Text;
    }

    private async Task<string> BuildInventoryContextAsync()
    {
        try
        {
            var vehicles = await _vehicleService.GetAllAsync();
            var vehicleList = vehicles.Take(20).ToList();

            if (vehicleList.Count == 0)
                return "No vehicles currently listed.";

            var lines = vehicleList.Select(v =>
                $"- {v.Brand} {v.Model ?? ""} ({v.Year}), " +
                $"Price: {(v.Price.HasValue ? $"€{v.Price:N0}" : "N/A")}, " +
                $"Rental: {(v.RentalPrice.HasValue ? $"€{v.RentalPrice:N0}/day" : "N/A")}, " +
                $"Location: {v.Location ?? "N/A"}, " +
                $"Mileage: {(v.Mileage.HasValue ? $"{v.Mileage:N0} km" : "N/A")}"
            );

            return string.Join("\n", lines);
        }
        catch
        {
            return "Inventory data temporarily unavailable.";
        }
    }
}
