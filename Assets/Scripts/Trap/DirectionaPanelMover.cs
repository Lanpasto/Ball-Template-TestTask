using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class DirectionaPanelMover : MonoBehaviour
{
    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    [Header("Movement Settings")]
    [SerializeField] private MoveDirection moveDirection;
    [SerializeField] private float acceleration;
    private Rigidbody2D rigiBody;
    private Collider2D boxCollider;

    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        rigiBody.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Move(other.GetComponent<Rigidbody2D>());
        }
    }

    private void Move(Rigidbody2D playerRb)
    {
        Vector2 direction = Vector2.zero;

        switch (moveDirection)
        {
            case MoveDirection.Up:
                direction = Vector2.up;
                break;
            case MoveDirection.Down:
                direction = Vector2.down;
                break;
            case MoveDirection.Left:
                direction = Vector2.left;
                break;
            case MoveDirection.Right:
                direction = Vector2.right;
                break;
        }

        playerRb.velocity += direction * acceleration;
    }
}
