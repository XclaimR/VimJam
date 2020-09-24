using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    public PlayerScore ps;
    public EnemyScore es;
    public Text winner;

    void Start()
    {
        //StartCoroutine(DeclareWinner());
    }

    public void DeclareWinner()
    {
        if (ps.score > es.score)
        {
            Debug.Log("Astro Wins");
            winner.text = "Player 1 wins";
            PlayerPrefs.SetInt("AstroRound", PlayerPrefs.GetInt("AstroRound") + 1);
        }
        if (es.score > ps.score)
        {
            winner.text = "Player 2 wins";
            Debug.Log("Alien Wins");
            PlayerPrefs.SetInt("AlienRound", PlayerPrefs.GetInt("AlienRound") + 1);
        }
        if(ps.score == es.score)
        {
            winner.text = "Tied";
            Debug.Log("Tied");
        }
        winner.enabled = true;
        Invoke("ChangeScene", 2);
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(RandomScene(1,4,SceneManager.GetActiveScene().buildIndex));
    }

    int RandomScene(int min, int max, int except)
    {
        int result = except;
        while(result == except)
        {
            result = Random.Range(min, max);
        }
        return result;
    }

    
}
