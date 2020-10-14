using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class gameData
{
    public bool[] levels = new bool[100];
    public bool[] particles = new bool[300];
    public int particleCount = 0;
    //public int HRUnit=0;

  
    public gameData(SaveController save)
    {
        for (int i = 0; i < 100; i++)
        {
            levels[i] = save.levels[i];
        }
        for (int a = 0; a < 300; a++)
        {
            particles[a] = save.particles[a];
        }

        particleCount = save.particleCount;
        //HRUnit=save.HRUnit;
    }
}
