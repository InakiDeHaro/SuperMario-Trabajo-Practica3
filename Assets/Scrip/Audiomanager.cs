using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class Audiomanager : MonoBehaviour
{
<<<<<<< HEAD
    public static Audiomanager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private void Awake()
    {
        if (!instance) //comprueba que instance no tenga informacion
=======
      public Sound[] musicSounds, sfxSounds;
      public AudioSource musicSource, SfxSource;
      public static Audiomanager instance;

    private void Awake()
    {
        if (!instance)
>>>>>>> ec7a36166cf134090f6d11242cff8b7e2cc07210
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
<<<<<<< HEAD
        else //si tiene info, ya existe un GM
=======
        else
>>>>>>> ec7a36166cf134090f6d11242cff8b7e2cc07210
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
<<<<<<< HEAD
        //busca en el array el nombre de la cancion escrita, si no lo encuentra pone que no lo encontró y si si lo reproduce en el music source en loop
        Sound s = Array.Find(musicSounds, x => x.Name == name);
        if (s == null) { Debug.LogWarning("sound not found"); }
=======
        Sound s = Array.Find(musicSounds, x => x.Name == name);
        if(s == null) 
        {
            Debug.LogWarning("sound not found"); 
        }
>>>>>>> ec7a36166cf134090f6d11242cff8b7e2cc07210
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
<<<<<<< HEAD
    public void PlaySFX(string name)
    {
        //busca en el array el nombre de la cancion escrita, si no lo encuentra pone que no lo encontró y si si lo reproduce en el sfx source una vez
        Sound s = Array.Find(sfxSounds, x => x.Name == name);
        if (s == null) { Debug.LogWarning("sound not found"); }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
=======

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









>>>>>>> ec7a36166cf134090f6d11242cff8b7e2cc07210
}


