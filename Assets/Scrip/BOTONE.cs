using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOTONE : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        GameManager.instance.ChangeScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void PlaySFX(string name)
    {
        Audiomanager.instance.PlaySFX(name);
    }
}
