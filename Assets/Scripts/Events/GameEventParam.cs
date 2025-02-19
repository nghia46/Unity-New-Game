using System;
using UnityEngine;

public abstract class GameEventParam<T> : ScriptableObject
{
    private event Action<T> Listeners;

    public void Subscribe(Action<T> listener)
    {
        Listeners += listener;
    }

    public void Unsubscribe(Action<T> listener)
    {
        Listeners -= listener;
    }

    public void Invoke(T data)
    {
        Debug.Log($"[GameEvent] Active event: {name} with data: {data}");
        Listeners?.Invoke(data);
    }
}
