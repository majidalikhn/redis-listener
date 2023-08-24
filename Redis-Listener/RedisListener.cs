namespace RedisLibrary;

using System;
using StackExchange.Redis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class RedisListener
{
    private ConnectionMultiplexer redis;
    private ISubscriber sub;

    public event EventHandler<MessageEventArgs> MessageReceived;

    public RedisListener(string serverAddress)
    {
        try
        {
            redis = ConnectionMultiplexer.Connect(serverAddress ?? "localhost:6379");
            sub = redis.GetSubscriber();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to Redis: {ex.Message}");
        }
    }

    public void Subscribe(string channelPattern)
    {
        try
        {
            sub.Subscribe(channelPattern, (channel, message) =>
            {
                string messageString = message.ToString();
                string beautified;

                try
                {
                    // Attempt to parse the message string into a JObject
                    var jsonObject = JObject.Parse(messageString);
                    
                    // Beautify the JSON string
                    beautified = jsonObject.ToString(Formatting.Indented);
                }
                catch (JsonReaderException)
                {
                    // The message string couldn't be parsed into a JSON object.
                    beautified = messageString;
                }

                MessageReceived?.Invoke(this, new MessageEventArgs(channel.ToString(), beautified));
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error subscribing to channel: {ex.Message}");
        }
    }
}

public class MessageEventArgs : EventArgs
{
    public string Channel { get; }
    public string Message { get; }

    public MessageEventArgs(string channel, string message)
    {
        Channel = channel;
        Message = message;
    }
}