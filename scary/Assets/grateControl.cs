using Unity.VisualScripting;
using UnityEngine;

public class grateControl : MonoBehaviour
{
    public BoxCollider2D hi;
    public Vector3 target;
    private bool moved = false;
    private bool moving = false;
    private int moveSpeed = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        }
        if (Vector2.Distance(transform.position, target) <= 0.1)
        {
            moving = false;
        }
        if (moving)
        {
            transform.position += new Vector3(0, moveSpeed * Time.deltaTime);
        }
    }
    public void moveAway()
    {
        if (!moved)
        {
            moving = true;
            moved = true;
        }
    }
}
