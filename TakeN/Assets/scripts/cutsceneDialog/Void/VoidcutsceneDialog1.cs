using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class VoidcutsceneDialog1 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public TextMeshProUGUI textDisplay2;
    public string[] sentences;
    public int index = 0;

    public float typingSpeed;
    public GameObject continueButton;
    public GameObject Mcamera;
    public bool moveCamera = false;
    public float cameraSpeed;

    public Animator anim;
    public Animator BlackScreenFade;

    private bool controlled = false;   //its a control for continueButton's single activation in update function after camera move
    private bool isEnded = false;
    private void Start()
    {
        StartCoroutine(type(textDisplay));
    }

    private void Update()
    {
        if(isEnded==true)
        {
            StartCoroutine(LoadLevel(3));
        }
        if (index == 13)
        {
            anim.SetBool("isBreaking", true);
            anim.SetBool("isOutro", false);
        }
        else if (index == 16)
        {
            anim.SetBool("isBreaking", false);
            anim.SetBool("isOutro", true);
        }
        if (textDisplay.text==sentences[index] || textDisplay2.text==sentences[index])
        {          
            continueButton.SetActive(true);
        }
        if(moveCamera==true && Mcamera.transform.position.y<-0.05f)
        {
            Mcamera.transform.position += Mcamera.transform.up * cameraSpeed * Time.deltaTime;
        }
        if(Mcamera.transform.position.y>= -0.05f)
        {
            moveCamera = false;
            cameraSpeed = 0f;

            if(controlled==false)
            {
                controlled = true;
                StartCoroutine(waitForIt(1f));               
            }
        }
    }
    IEnumerator type(TextMeshProUGUI dialog)
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            dialog.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    IEnumerator LoadLevel(int index)
    {
        BlackScreenFade.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }

    IEnumerator waitForIt(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        nextSentence();
    }
    public void nextSentence()
    {
        if(Mcamera.transform.position.y<-1)
        {
            continueButton.SetActive(false);
            if (index < sentences.Length - 9)
            {
                index++;
                textDisplay.text = "";
                StartCoroutine(type(textDisplay));
            }
            else
            {
                textDisplay.text = "";
                continueButton.SetActive(false);
                moveCamera = true;
            }
        }
        else
        {
            continueButton.SetActive(false);
            if (index < sentences.Length - 1)
            {
                index++;
                textDisplay2.text = "";
                StartCoroutine(type(textDisplay2));
          
            }
            else
            {
                textDisplay2.text = "";
                continueButton.SetActive(false);
                isEnded = true;
            }
        }
    }
}
