using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerInt : MonoBehaviour
{
    public GameEventInt gameEvent;
    public UnityEvent<int> response; // UnityEvent hỗ trợ truyền int

    private void OnEnable()
    {
        if (gameEvent != null)
            gameEvent.Subscribe(OnEventRaised);
    }

    private void OnDisable()
    {
        if (gameEvent != null)
            gameEvent.Unsubscribe(OnEventRaised);
    }

    private void OnEventRaised(int value)
    {
        response.Invoke(value);
    }
}
