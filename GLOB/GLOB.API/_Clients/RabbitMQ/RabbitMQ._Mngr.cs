using System.Collections.Concurrent;
using RabbitMQ.Client;

namespace GLOB.API.Clientz;

public class ChannelManager : IDisposable
{
    private readonly IConnection _connection;
    private readonly ConcurrentDictionary<string, IModel> _channels = new();

    public ChannelManager(IConnection connection)
    {
        _connection = connection;
    }

    public IModel GetOrCreateChannel(string key)
    {
        return _channels.GetOrAdd(key, _ => _connection.CreateModel());
    }

    public void DisposeChannel(string key)
    {
        if (_channels.TryRemove(key, out var channel))
        {
            if (channel.IsOpen) channel.Close();
            channel.Dispose();
        }
    }

    public void Dispose()
    {
        foreach (var ch in _channels.Values)
        {
            if (ch.IsOpen) ch.Close();
            ch.Dispose();
        }
        _channels.Clear();
    }
}