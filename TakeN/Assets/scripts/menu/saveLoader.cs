using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveLoader : MonoBehaviour
{
    private GameObject load;
    void Start()
    {
        load= GameObject.Find("GameSaveManager");

        load.GetComponent<SaveController>().LoadGame();
    }

 
}
