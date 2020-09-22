using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetWinner : MonoBehaviour
{
    public Text winnerText;
    void Start()
    {
        int winner = PlayerPrefs.GetInt("Winner");
        if(winner == 0)
        {
            winnerText.text = "Winner is Astro";
        }
        if(winner == 1)
        {
            winnerText.text = "Winner is Alien";
        }
    }

   
}
