using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent response;

    private void OnEnable()
    {
        gameEvent.Subscribe(OnEventRaised);
    }

    private void OnDisable()
    {
        gameEvent.Unsubscribe(OnEventRaised);
    }

    private void OnEventRaised()
    {
        response.Invoke();
    }
}
