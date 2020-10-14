using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rusher : MonoBehaviour
{
    public GameObject player;
    public Transform trigger;
    private Animator anim;
    private Rigidbody2D rb;

    public float speed;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(player.transform.position.x>=trigger.position.x)
        {
            anim.SetBool("isTrigger", true);
            anim.SetBool("isRunning", false);
            StartCoroutine(attack());
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "HE" || coll.gameObject.name == "SHE")
        {
            player.GetComponent<playables>().health -= 1;
        }
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isTrigger", false);
        anim.SetBool("isRunning", true);
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
