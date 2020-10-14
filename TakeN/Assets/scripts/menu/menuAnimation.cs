using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAnimation : MonoBehaviour
{
    private bool isChange = false;
    private bool isChangeBack = true;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.SetBool("isChange", false);
        anim.SetBool("changeBack", false);
    }

    public void change()
    {
        if(isChange==false && isChangeBack==true)
        {
            anim.SetBool("isChange", true);
            anim.SetBool("changeBack", false);
            isChange = true;
            isChangeBack = false;
        }

        else if(isChangeBack==false && isChange==true)
        {
            anim.SetBool("isChange", false);
            anim.SetBool("changeBack", true);
            isChange = false;
            isChangeBack = true;
        }
    }
}
