using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EnemyScore : MonoBehaviour
{
    
    public Text text;
    private int score = 0;
    

    void Start()
    {
        setScore();
    }

    void Update()
    {
        if (Input.GetKey("escape")) { 
            PlayerPrefs.SetInt("AlienScore", 0);
            Application.Quit();
        }
    }

    private void setScore()
    {
        score = PlayerPrefs.GetInt("AlienScore");
        text.text = score.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("AlienScore", score+1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
