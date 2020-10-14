using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    private GameObject saveManager;

    public int LevelNumber;
    public bool isLevelComplete = false;
    public GameObject EndLevel;
    public GameObject player;
    public Button pauseButton;
    private Animator anim;

    public GameObject loadingScreenUI;
    public GameObject progressBar;
    private bool off = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        saveManager = GameObject.Find("GameSaveManager");
    }
    private void Update()
    {
        if (player.transform.position.x >= EndLevel.transform.position.x)
        {
            isLevelComplete = true;
            saveManager.GetComponent<SaveController>().levels[LevelNumber - 1] = true;
            saveManager.GetComponent<SaveController>().SaveGame();
            pauseButton.interactable = false;
            if(off==false)
            {
                anim.SetBool("isComplete", true);
            }
            else if(off==true)
            {
                anim.SetBool("isComplete", false);
                anim.SetBool("off", true);
            }
        }
    }

    public void mainmenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void restart()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex)));
    }
    public void levelSelect()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void nextLevel()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }


    IEnumerator LoadLevel(int index)
    {
        off = true;
        loadingScreenUI.SetActive(true);
        progressBar.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(index);
    }
}

