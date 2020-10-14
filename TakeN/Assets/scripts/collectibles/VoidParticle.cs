using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidParticle : MonoBehaviour
{
    public int number;
    private GameObject saveManager;
    private void Start()
    {
        saveManager = GameObject.Find("GameSaveManager");
    }

    private void Update()
    {
        if(saveManager.GetComponent<SaveController>().particles[number-1]==true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "HE" || coll.gameObject.name == "SHE")
        {
            saveManager.GetComponent<SaveController>().particles[number - 1] = true;
            saveManager.GetComponent<SaveController>().particleCount++;
            saveManager.GetComponent<SaveController>().SaveGame();
        }
    }
}
