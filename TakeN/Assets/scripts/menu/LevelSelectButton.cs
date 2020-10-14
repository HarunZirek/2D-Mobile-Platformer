using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelectButton : MonoBehaviour
{
    private GameObject saveManager;

    public int SceneToOpen;
    public int levelNumber;
    public Animator anim;
    public GameObject loadingScreenUI;

    public Button isOpen;
    private void Start()
    {
        saveManager = GameObject.Find("GameSaveManager");
        isOpen.interactable = false;
    }

    private void Update()
    {
        if(levelNumber==1)
        {
            isOpen.interactable = true;
            return;
        }
        else
        {
           if (saveManager.GetComponent<SaveController>().levels[levelNumber - 2]==true)
            {
                isOpen.interactable = true;
            }
        }
    }
    public void openLevel()
    {
        StartCoroutine(LoadLevel(SceneToOpen));
    }

    IEnumerator LoadLevel(int index)
    {
        loadingScreenUI.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(index);
    }
}
