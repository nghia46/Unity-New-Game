using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputReader inputReader;
    public float moveSpeed = 5f;
    public int health = 100;
    private Vector2 moveInput;


    public GameEvent onPlayerAttack;
    public GameEventInt onPlayerTakeDamage;
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
        TakeDamage(10);
        Debug.Log("Click");
    }
    public void Attack()
    {
        onPlayerAttack.Invoke();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        onPlayerTakeDamage.Invoke(damage);
        Debug.Log("Take Damage");
    }
}
