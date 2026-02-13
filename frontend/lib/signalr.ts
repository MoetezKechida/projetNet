import {
  HubConnectionBuilder,
  HubConnection,
  LogLevel,
  HttpTransportType,
} from "@microsoft/signalr";

const API_BASE = process.env.NEXT_PUBLIC_API_URL || "http://localhost:5234";

/**
 * Creates a new SignalR hub connection for the given hub path.
 * Automatically attaches the JWT from localStorage.
 */
export function createHubConnection(hubPath: string): HubConnection {
  return new HubConnectionBuilder()
    .withUrl(`${API_BASE}${hubPath}`, {
      accessTokenFactory: () => localStorage.getItem("token") ?? "",
      transport: HttpTransportType.WebSockets,
      skipNegotiation: true,
    })
    .withAutomaticReconnect([0, 2000, 5000, 10000, 30000])
    .configureLogging(LogLevel.Warning)
    .build();
}
