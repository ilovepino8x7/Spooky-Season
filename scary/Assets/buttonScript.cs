using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public GameObject linkedGate;
    public tutorial tt;
    public AudioSource aud;
    public AudioClip ac;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            aud.PlayOneShot(ac);
            if (tt != null)
            {
                tt.switchTutorial(8);
            }
            linkedGate.GetComponent<grateControl>().moveAway();
        }
    }
}
