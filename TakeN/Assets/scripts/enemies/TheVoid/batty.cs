using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batty : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Transform bottom;
    public Transform top;
    private Rigidbody2D rb;
    private bool isUp = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x, speed);

        if(transform.position.y>=top.position.y && isUp==true)
        {
            flip();
        }
        else if(isUp==false && transform.position.y <= bottom.position.y)
        {
            flip();
        }
    }

    private void flip()
    {
        speed = speed * -1;
        isUp = !isUp;
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "HE" || coll.gameObject.name == "SHE")
        {
            player.GetComponent<playables>().health -= 1;
        }
    }
}
