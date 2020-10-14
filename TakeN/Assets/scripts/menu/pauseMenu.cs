using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject loadingScreenUI;
    public GameObject progressBar;
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
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

}
