using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputReader inputReader;
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private void OnEnable()
    {
        inputReader.MoveEvent += HandleMove;
        inputReader.OnClickEvent += HandleClick;

    }
    private void OnDisable()
    {
        inputReader.MoveEvent -= HandleMove;
        inputReader.OnClickEvent -= HandleClick;
    }

    private void HandleMove(Vector2 movement)
    {
        moveInput = movement;
        Debug.Log(moveInput);
    }
    private void HandleClick()
    {
        HapticGameManager.Instance.PlayHaptic(0.5f, 0.5f, 0.1f);
        Debug.Log("Click");
    }
}
