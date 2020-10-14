using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tutorialScreen : MonoBehaviour
{
    public GameObject Tposition;
    public GameObject player;
    public Button pauseButton; 
    private Animator anim;
    private float control = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if(player.transform.position.x>=Tposition.transform.position.x && control>0)
        {
            pauseButton.interactable = false;
            anim.SetBool("on",true);
            Time.timeScale = 0f;
            control--;
        }
    }
    
    public void disable()
    {
        anim.SetBool("on", false);
        anim.SetBool("off", true);
        StartCoroutine(DisableTutorial());       
    }


   
    IEnumerator DisableTutorial()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1f;
        pauseButton.interactable = true;
    }
}
