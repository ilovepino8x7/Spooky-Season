using UnityEngine;

public class playerMove : MonoBehaviour
{
    private int moveSpeed = 7;
    private bool grounded = false;
    private int moving = 0;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moving = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving = 1;
        }
        else
        {
            moving = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveSpeed);
            grounded = false;
        }
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving == -1)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else if (moving == 1)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else if (moving == 0)
        {
            rb.linearVelocity = new Vector2 (0, rb.linearVelocity.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "land")
        {
            grounded = true;
        }
    }
}
