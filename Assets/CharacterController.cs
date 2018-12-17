using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed = 10f;
    public float JumpForce = 10f;
    private Animator animator;
    private Vector2 positionBeforeJump;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
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

        if (isTouchingFloor)
        {
            positionBeforeJump = gameObject.transform.position;
        }

        if (isJumping && isTouchingFloor)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    private void Die()
    {
        gameObject.transform.position = positionBeforeJump;
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var name = collision.collider.name;
        switch(name)
        {
            case "Death":
                Die();
                break;
        }
    }
}
