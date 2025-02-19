using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputReader inputReader;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] int jumpForce = 10;

    [SerializeField] GameEventInt onPlayerTakeDamage;
    [SerializeField] GameEvent onPlayerAttack;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    private bool wasOnGround;
    private bool IsOnGround;
    private bool isFacingRight = true;
    private void OnEnable()
    {
        inputReader.MoveEvent += HandleMove;
        inputReader.OnJumpEvent += HandleJump;

    }
    private void OnDisable()
    {
        inputReader.MoveEvent -= HandleMove;
        inputReader.OnJumpEvent -= HandleJump;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (moveInput != Vector2.zero)
        {
            rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocityY);
        }
        animator.SetFloat("move", Mathf.Abs(moveInput.x));

        CheckGroundedHaptic();
        Flip();
    }

    private void Flip()
    {
        if (moveInput.x > 0 && !isFacingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = true;
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = false;
        }
    }

    private void CheckGroundedHaptic()
    {
        if (IsOnGround && !wasOnGround)
        {
            HapticGameManager.Instance.PlayQuickHaptic();
        }

        wasOnGround = IsOnGround; // Cập nhật trạng thái trước đó
    }
    private void HandleMove(Vector2 movement)
    {
        moveInput = movement;
    }
    private void HandleJump()
    {
        if (IsOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IGround>(out _))
        {
            IsOnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IGround>(out _))
        {
            IsOnGround = false;
        }
    }
}
