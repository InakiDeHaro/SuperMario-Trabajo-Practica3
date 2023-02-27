using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
public class Audiomanager : MonoBehaviour
{

    public static Audiomanager instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private void Awake()
    {
        if (!instance) //comprueba que instance no tenga informacion





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

        //busca en el array el nombre de la cancion escrita, si no lo encuentra pone que no lo encontró y si si lo reproduce en el music source en loop
        Sound s = Array.Find(musicSounds, x => x.Name == name);
        if (s == null) { Debug.LogWarning("sound not found"); }

      


        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

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











}


