using Core.CrossCuttingConcerns.Caching.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

public class MemoryCacheManager : IMemoryCacheManager
{
    private readonly IDatabase _redisDatabase;
    private readonly ConnectionMultiplexer _redisConnection;

    public MemoryCacheManager(string connectionString)
    {
        _redisConnection = ConnectionMultiplexer.Connect(connectionString);
        _redisDatabase = _redisConnection.GetDatabase();
    }

    public void Add(string key, object data, int duration)
    {
        _redisDatabase.StringSet(key, Serialize(data), TimeSpan.FromMinutes(duration));
    }

    public void Add(string key, object data)
    {
        _redisDatabase.StringSet(key, Serialize(data));
    }

    public T? Get<T>(string key)
    {
        var value = _redisDatabase.StringGet(key);
        return value.IsNull ? default : Deserialize<T>(value);
    }

    public object? Get(string key)
    {
        var value = _redisDatabase.StringGet(key);
        return value.IsNull ? null : Deserialize<object>(value);
    }

    public bool IsAdd(string key)
    {
        return _redisDatabase.KeyExists(key);
    }

    public void Remove(string key)
    {
        _redisDatabase.KeyDelete(key);
    }

    public void RemoveByPattern(string pattern)
    {
        var server = _redisConnection.GetServer(_redisConnection.GetEndPoints().First());
        var keysToRemove = server.Keys(pattern: pattern + "*").ToArray();
        foreach (var key in keysToRemove)
        {
            _redisDatabase.KeyDelete(key);
        }
    }

    private byte[]? Serialize(object obj)
    {
        if (obj == null)
            return null;
        
        var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        return System.Text.Encoding.UTF8.GetBytes(jsonString);
    }

    private T? Deserialize<T>(byte[] bytes)
    {
        if (bytes == null)
            return default;
        
        var jsonString = System.Text.Encoding.UTF8.GetString(bytes);
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);
    }
}