using System;
using UnityEngine;

public enum MessagePriority
{
    Normal,
    Warning,
    Error
}

/// <summary>
/// Contains functions for readily available generic output messages.
/// </summary>
public static class StandardMessages
{
    /// <summary>
    /// Missing component message
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source">The source.</param>
    /// <param name="level">The priority level.</param>
    public static void MissingComponent<T>(Behaviour source, MessagePriority level = MessagePriority.Warning)
    where T : Component
    {
        string message = "Missing " + typeof(T) + " component.";
        LogMessage(source, message, level);
    }

    /// <summary>
    /// Missing asset message
    /// </summary>
    /// <param name="source"></param>
    /// <param name="level"></param>
    public static void MissingAsset<T>(Behaviour source, MessagePriority level = MessagePriority.Warning)
    where T : ScriptableObject
    {
        string message = "Missing " + typeof(T) + " asset.";
        LogMessage(source, message, level);
    }

    /// <summary>
    /// Disable behaviour message. If disable = true, it will disable the given behavior as well.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="disable">if set to <c>true</c> [disable].</param>
    /// <param name="level">The level.</param>
    public static void DisablingBehaviour(Behaviour source, bool disable = true,
                                          MessagePriority level = MessagePriority.Warning)
    {
        string message = "Disabling behavior...";
        source.enabled = !disable;
        LogMessage(source, message, level);
    }

    /// <summary>
    /// Logs the message.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="message">The message.</param>
    /// <param name="level">The level.</param>
    /// <exception cref="System.ArgumentOutOfRangeException">level;null</exception>
    private static void LogMessage(UnityEngine.Object source, string message, MessagePriority level)
    {
        message = source + ": " + message;

        switch (level)
        {
            case MessagePriority.Normal:
                Debug.Log(message);
                break;

            case MessagePriority.Warning:
                Debug.LogWarning(message);
                break;

            case MessagePriority.Error:
                Debug.LogError(message);
                break;

            default:
                throw new ArgumentOutOfRangeException("level", level, null);
        }
    }
}

