using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    private int moveSpeed = 7;
    private bool grounded = false;
    private bool isGhost = false;
    private bool startedReset = false;
    private bool doneGhost;
    public int toBuild = 0;
    private bool doneProof;
    private int moving = 0;
    private Rigidbody2D rb;
    public tutorial tt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isGhost)
        {
            rb.gravityScale = 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isGhost = !isGhost; 
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
            rb.linearVelocity = new Vector2(0, 0);
            rb.gravityScale = 0;
            gameObject.layer = 7;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.linearVelocity = new Vector2(0, 0);
                transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.linearVelocity = new Vector2(0, 0);
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.linearVelocity = new Vector2(0, 0);
                transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.linearVelocity = new Vector2(0, 0);
                transform.position += new Vector3(0, -moveSpeed * Time.deltaTime);
            }
            if (SceneManager.GetActiveScene().name == "LevelFour" && !startedReset)
            {
                startedReset = true;
                StartCoroutine(resetToPlayer(1));
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
        if (collision.gameObject.layer == 8)
        {
            grounded = true;
        }
        else if (collision.gameObject.tag == "door" && !doneGhost)
        {
            if (tt != null)
            {
                doneGhost = true;
                tt.switchTutorial(5);
            }
        }
        else if (collision.gameObject.tag == "proof" && !doneProof && gameObject.layer == 7)
        {
            if (tt != null)
            {
                doneProof = true;
                tt.switchTutorial(7);
            }
        }
    }
    public IEnumerator resetToPlayer(int length = 0)
    {
        yield return new WaitForSeconds(length);
        isGhost = false;
        startedReset = false;
        rb.gravityScale = 0.5f;
    }
}
