using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Events/New Event")]
public class GameEvent : ScriptableObject
{
    private readonly List<Action> listeners = new();

    public void Subscribe(Action listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void Unsubscribe(Action listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

    public void Invoke()
    {
        Debug.Log($"[GameEvent] Kích hoạt event: {name}");
        foreach (var listener in listeners)
        {
            listener.Invoke();
        }
    }
}
