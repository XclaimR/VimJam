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
            winnerText.color = new Color(255f / 255f, 28f / 255f, 28f/255f);
            winnerText.text = "Player 1";
        }
        if(winner == 1)
        {
            winnerText.color = new Color(87f / 255f, 221f / 255f, 24f / 255f);
            winnerText.text = "Player 2";
        }
    }

   
}
