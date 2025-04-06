using System;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    private static Dictionary<Type, object> services = new();

    public static void Register<T>(T service) where T : class
    {
        var type = typeof(T);
        if (services.ContainsKey(type))
        {
            Debug.LogWarning($"Service of type {type} is already registered.");
            return;
        }

        services[type] = service;
    }

    public static T Get<T>() where T : class
    {
        var type = typeof(T);
        if (services.TryGetValue(type, out var service))
        {
            return service as T;
        }

        Debug.LogError($"Service of type {type} not found.");
        return null;
    }

    public static void Clear()
    {
        services.Clear();
    }
}
