import { apiFetch } from "./client";

interface ChatResponse {
  reply: string;
}

export async function sendChatMessage(message: string): Promise<string> {
  const res = await apiFetch<ChatResponse>("/api/chat", {
    method: "POST",
    body: JSON.stringify({ message }),
  });
  return res.reply;
}
