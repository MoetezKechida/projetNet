"use client";

import { useEffect, useRef, useCallback } from "react";
import type { HubConnection } from "@microsoft/signalr";
import { HubConnectionState } from "@microsoft/signalr";
import { createHubConnection } from "@/lib/signalr";

/**
 * React hook that manages a SignalR hub connection lifecycle.
 *
 * @param hubPath  - The server hub path, e.g. "/hubs/booking"
 * @param handlers - A record of event names → callback functions
 * @param enabled  - Whether the connection should be active (default true)
 */
export function useSignalR(
  hubPath: string,
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  handlers: Record<string, (...args: any[]) => void>,
  enabled = true
) {
  const connectionRef = useRef<HubConnection | null>(null);
  const handlersRef = useRef(handlers);

  // Keep handler references up-to-date without re-connecting
  useEffect(() => {
    handlersRef.current = handlers;
  }, [handlers]);

  const startConnection = useCallback(async () => {
    if (!enabled) return;

    const token = localStorage.getItem("token");
    if (!token) return;

    // Tear down any existing connection
    if (connectionRef.current) {
      try {
        await connectionRef.current.stop();
      } catch {
        // ignore stop errors
      }
    }

    const connection = createHubConnection(hubPath);

    // Register event handlers
    for (const [event, handler] of Object.entries(handlersRef.current)) {
      // eslint-disable-next-line @typescript-eslint/no-explicit-any
      connection.on(event, (...args: any[]) => {
        handlersRef.current[event]?.(...args);
      });
    }

    connection.onclose(() => {
      console.info(`[SignalR] Connection to ${hubPath} closed.`);
    });

    try {
      await connection.start();
      console.info(`[SignalR] Connected to ${hubPath}`);
      connectionRef.current = connection;
    } catch (err) {
      console.error(`[SignalR] Failed to connect to ${hubPath}:`, err);
    }
  }, [hubPath, enabled]);

  useEffect(() => {
    startConnection();

    return () => {
      const conn = connectionRef.current;
      if (conn && conn.state !== HubConnectionState.Disconnected) {
        conn.stop().catch(() => {});
      }
    };
  }, [startConnection]);
}
