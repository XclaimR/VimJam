using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EnemyScore : MonoBehaviour
{
    GameObject collectible;
    public Text text;
    public static int score = 0;
    public int winScore = 5;
    public bool isHolding = false;
    public GameObject collectibleloc;
    bool follow = false;
    public static List<GameObject> inZone = new List<GameObject>();

    private void setScore()
    {
        //score = PlayerPrefs.GetInt("AlienScore");
        text.text = score.ToString();
    }

    void Update()
    {
        if (Input.GetKey("escape")) { 
            PlayerPrefs.SetInt("AlienScore", 0);
            Application.Quit();
        }
        if (follow == true)
        {
            collectible.transform.position = collectibleloc.transform.position;
        }
        setScore();
    }

    void Start()
    {
        //setScore();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Collectible" && isHolding == false && !inZone.Contains(collider.gameObject))
        {
            follow = true;

            collectible = collider.gameObject;
            isHolding = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collider.gameObject.tag == "Collectible" && PlayerScore.inZone.Contains(collider.gameObject))
        {
            PlayerScore.inZone.Remove(collider.gameObject);
            PlayerScore.score--;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "MoonGround" && isHolding == true)
        {
            score++;
            //PlayerPrefs.SetInt("AlienScore", score);
            text.text = score.ToString();
            if (score == winScore)
            {
                Debug.Log("Alien Won");
                //PlayerPrefs.SetInt("AstroScore", 0);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            inZone.Add(collectible);
            collectible = null;
            isHolding = false;
            follow = false;
        }
    }
}
