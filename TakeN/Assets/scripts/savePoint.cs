using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePoint : MonoBehaviour
{
    public GameObject player;
    Animator anim;
    int saveCount = 1;
    public bool isSaved;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(player.transform.position.x>=transform.position.x &&saveCount==1)
        {
            isSaved = true;
            saveCount--;
            anim.SetBool("isSaved", true);
        }
        else if(player.transform.position.x > transform.position.x)
        {
            anim.SetBool("isSaved", false);
        }
    }
}
