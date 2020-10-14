using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject gameOverScreen;
    public GameObject loadingScreenUI;
    public GameObject progressBar;
    public GameObject player;
    public GameObject savePoint;
    public Button pauseButton;

    public Button reviveButton;

    public int reviveCount = 1;
    private void FixedUpdate()
    {
    
       if (player.GetComponent<playables>().health<1)
        {
            gameOverScreen.SetActive(true);
            pauseButton.interactable = false;
        }
        else if (player.GetComponent<playables>().health > 0 )
        {
            gameOverScreen.SetActive(false);
            pauseButton.interactable = true;
        }

       if(savePoint.GetComponent<savePoint>().isSaved==false || reviveCount==0)
        {
            reviveButton.interactable = false;
        }
       else if(savePoint.GetComponent<savePoint>().isSaved==true)
        {
            reviveButton.interactable = true;
        }
    }
 
    public void mainmenu()
    {
        StartCoroutine(LoadLevel(0));
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void restart()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex)));
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void levelSelect()
    {
        StartCoroutine(LoadLevel(1));
        Time.timeScale = 1f;
        isPaused = false;
    }


    IEnumerator LoadLevel(int index)
    {
        loadingScreenUI.SetActive(true);
        progressBar.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }

    IEnumerator reviveTime()
    {
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<playables>().isPlaying = true;
    }
    public void revive()
    {
            player.GetComponent<playables>().health=1;
            player.transform.position = new Vector3(savePoint.transform.position.x, savePoint.transform.position.y, transform.position.z);
            StartCoroutine(reviveTime());
    }
}
