using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rounds : MonoBehaviour
{
    // Update is called once per frame
    public Text roundText;
    void Start()
    {
        roundText.text = PlayerPrefs.GetInt("AstroRound") + " : " + PlayerPrefs.GetInt("AlienRound");      
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("AstroRound") == 2)
        {
            PlayerPrefs.SetInt("Winner", 0);
            Debug.Log("GAME OVER ASTRO WINS");
            PlayerPrefs.SetInt("AstroRound", 0);
            PlayerPrefs.SetInt("AlienRound", 0);
            Invoke("ChangeScene", 2);
        }
        if(PlayerPrefs.GetInt("AlienRound") == 2)
        {
            PlayerPrefs.SetInt("Winner", 1);
            Debug.Log("GAME OVER ALIEN WINS");
            PlayerPrefs.SetInt("AstroRound", 0);
            PlayerPrefs.SetInt("AlienRound", 0);
            Invoke("ChangeScene", 2);
        }
        
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
