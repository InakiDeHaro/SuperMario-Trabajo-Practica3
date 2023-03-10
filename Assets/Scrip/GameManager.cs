using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Audiomanager.instance.PlayMusic("Menu");
    }

    public static GameManager instance;

    private int puntuacion = 0;
    private float time = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance) // instance == null. comprueba que instance no contenga niguna informacion
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //y si tiene informacion, significa ya existe otro GM(GameManager)
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
    }
    // Update is called once per frame
    public void AddPunt(int value)
    {
        puntuacion += value;
    }
    public int GetPunt()
    {
        return puntuacion;
    }
    public float GetTime()
    {
        return time;
    }

    public void ChangeScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        puntuacion = 0; 
        time = 0;
        
        Audiomanager.instance.PlayMusic(name);
        Personaje.cointake = 0;
    }
}



