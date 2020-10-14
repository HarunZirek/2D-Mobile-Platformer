using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{ 
    public Animator anim;

    public void play()
    {
        StartCoroutine(LoadLevel(1));
    }
    
    IEnumerator LoadLevel(int index)
    {
        anim.SetTrigger("Fade");
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(index);
    }
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
