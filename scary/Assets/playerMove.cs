using System.Collections;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private int moveSpeed = 7;
    private bool grounded = false;
    private bool isGhost = false;
    private bool startedReset = false;
    private int moving = 0;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isGhost)
        {
            isGhost = true;
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !isGhost)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveSpeed);
            grounded = false;
        }
        transform.rotation = Quaternion.identity;
        if (isGhost)
        {
            rb.linearVelocity = new Vector2(0,0);
            rb.gravityScale = 0;
            gameObject.layer = 7;
            if (Input.GetKey(KeyCode.A))
            {
                rb.linearVelocity = new Vector2(0,0);
                transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rb.linearVelocity = new Vector2(0,0);
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                rb.linearVelocity = new Vector2(0,0);
                transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                rb.linearVelocity = new Vector2(0,0);
                transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
            }
            if (!startedReset)
            {
                startedReset = true;
                StartCoroutine(resetToPlayer());
            }
        }
        else
        {
            gameObject.layer = 6;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isGhost)
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
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "land")
        {
            grounded = true;
        }
    }
    public IEnumerator resetToPlayer()
    {
        yield return new WaitForSeconds(3);
        isGhost = false;
        startedReset = false;
        rb.gravityScale = 0.5f;
    }
}
