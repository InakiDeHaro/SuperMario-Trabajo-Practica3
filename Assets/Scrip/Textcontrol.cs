using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Textcontrol : MonoBehaviour
{
    public TMP_Text timeText, coinText, scoreText;
    void Update()
    {
        UpdateText();
        UpdateScore();
        UpdateCoin();
    }

    void UpdateText()
    {
        //el tiempo fluye
        timeText.text = "Time: " + string.Format("{0:0.##}", GameManager.instance.GetTime());
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + GameManager.instance.GetPunt();
    }

    void UpdateCoin()
    {
        coinText.text = "Coin: " + Personaje.cointake;
    }
}
