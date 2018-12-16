using UnityEngine;

public class CharacterController : MonoBehaviour {
    public float Speed = 10f;
    public float JumpForce = 10f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update ()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        var x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        transform.Translate(x, 0, 0);

        var isWalking = System.Math.Abs(x) > 0.1;
        animator.SetBool("IsWalking", isWalking);

        var isFacingLeft = x < 0;
        this.GetComponent<SpriteRenderer>().flipX = isFacingLeft;
    }

    private void Jump()
    {
        var isJumping = Input.GetKeyDown(KeyCode.Space);
        var rb = GetComponent<Rigidbody2D>();

        var isTouchingFloor = System.Math.Abs(rb.velocity.y) < 0.01;

        if (isJumping && isTouchingFloor)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
