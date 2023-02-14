using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Audiomanager : MonoBehaviour
{
      public Sound[] musicSounds, sfxSounds;
      public AudioSource musicSource, SfxSource;
      public static Audiomanager instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.Name == name);
        if(s == null) 
        {
            Debug.LogWarning("sound not found"); 
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX (string name)
    {
        Sound s = Array.Find(musicSounds, x => x.Name == name);
        if (s == null) 
        { 
            Debug.LogWarning("sound not found"); 
        }
        else
        {
            SfxSource.PlayOneShot(s.clip);
        }
    
    
    }









}


