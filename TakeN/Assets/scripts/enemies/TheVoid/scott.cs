using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scott : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Transform left;
    public Transform right;
    private Rigidbody2D rb;
    private bool isFacingRight = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (transform.position.x >= right.position.x && isFacingRight == true)
        {
            flip();
        }
        else if (isFacingRight == false && transform.position.x <= left.position.x)
        {
            flip();
        }
    }

    private void flip()
    {
        speed = speed * -1;
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
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
