using UnityEngine.Audio;
using System;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public sound[] sounds;

    public static audioManager instance;
    void Awake()
    {
        if(instance==null)
        {
            instance = this;    
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
        }
    }

    public void Play(string name)
    {
        sound s=Array.Find(sounds, sound => sound.name == name);
        s.source.Play(); 
    }
}
