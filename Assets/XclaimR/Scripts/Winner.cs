using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public PlayerScore ps;
    public EnemyScore es;
    public void DeclareWinner()
    {
        if (ps.score > es.score)
        {
            Debug.Log("Astro Wins");
            PlayerPrefs.SetInt("AstroRound", PlayerPrefs.GetInt("AstroRound") + 1);
        }
        if (es.score > ps.score)
        {
            Debug.Log("Alien Wins");
            PlayerPrefs.SetInt("AlienRound", PlayerPrefs.GetInt("AlienRound") + 1);
        }
        else
        {
            Debug.Log("Tied");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
}
