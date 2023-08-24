using System;
using RedisLibrary;

class Program
{
    static void Main(string[] args)
    {
        string serverAddress = Environment.GetEnvironmentVariable("REDIS_SERVER") ?? "localhost:6379";
        string channelPattern = Environment.GetEnvironmentVariable("REDIS_SUBSCRIPTION_CHANNEL") ?? "*";

        var listener = new RedisListener(serverAddress);
        
        // Register an event handler for the MessageReceived event
        listener.MessageReceived += (sender, e) => { Console.WriteLine($"Received from {e.Channel}:\n{e.Message}"); };
        
        listener.Subscribe(channelPattern);
        
        Console.WriteLine("Running... Press Ctrl+C to exit...");

        // Use a ManualResetEvent to wait indefinitely instead of Thread.Sleep
        var waitHandle = new System.Threading.ManualResetEvent(false);
        waitHandle.WaitOne();
    }
}