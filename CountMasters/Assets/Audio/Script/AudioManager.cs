using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1)
        {
            Destroy(objs[0]);
        }

        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    
    public void Play(string name){
        Sound s;
        s = Array.Find(sounds, sound => sound.name == name);
        
        s.source.Play();
    }

    public void Stop(){
        //Sound s;
        foreach (Sound a in sounds){
            a.source.Stop();
        }
        /*s = Array.Find(sounds, sound => sound.name == name);
        
        s.source.Stop();*/
    }
}
