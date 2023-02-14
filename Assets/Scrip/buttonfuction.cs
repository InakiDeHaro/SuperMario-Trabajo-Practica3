using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonfuction : MonoBehaviour
{
    public void changeScene(string name) 
    {
        GameManager.instance.changeScene(name);
    }
    
}
