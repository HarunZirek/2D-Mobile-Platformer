using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SaveController : MonoBehaviour
{
    public bool[] levels = new bool[100];
    public bool[] particles = new bool[300];
    public int particleCount = 0;
    //public int HRUnit=0;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);      
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
        else if(Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }

    }
    public void SaveGame()
    {
        GameSavingSystem.SaveGame(this);
    }

    public void LoadGame()
    {
        gameData data = GameSavingSystem.LoadGame();

        for (int i = 0; i < 100; i++)
        {
            levels[i] = data.levels[i];
        }
        for (int a = 0; a < 300; a++)
        {
            particles[a] = data.particles[a];
        }
        particleCount = data.particleCount;
    }
}
