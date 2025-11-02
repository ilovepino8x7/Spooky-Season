using UnityEngine;

public class patchScript : MonoBehaviour
{
    public GameObject[] things;
    private bool built = false;
    public playerMove pm;
    public Color start = Color.clear;
    public Color highlighted = Color.grey;
    private SpriteRenderer sp;
    public Animator anim;
    private bool open = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        pm = GameObject.Find("Player").GetComponent<playerMove>();
        anim = GameObject.Find("Menu").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buildThing()
    {
        if (!built)
        {
            Instantiate(things[pm.toBuild], transform.position, Quaternion.identity);
            built = true;
        }
    }
    void OnMouseEnter()
    {
        sp.color = highlighted;
    }
    void OnMouseExit()
    {
        sp.color = start;
    }
    public void SelGround()
    {
        pm.toBuild = 0;
    }
    public void SelGhostProof()
    {
        pm.toBuild = 1;
    }
    void OnMouseDown()
    {
        buildThing();
    }
  public void toggleMenu()
      {
        open = !open;
        anim.SetBool("isOpen", open);
    }
}
