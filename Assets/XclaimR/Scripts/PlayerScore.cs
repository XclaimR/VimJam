using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject collectible;
    public Text text;
    public static int score = 0;
    public int winScore = 5;
    public bool isHolding = false;
    public GameObject collectibleloc;
    bool follow = false;
    public static List<GameObject> inZone = new List<GameObject>();
    

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            PlayerPrefs.SetInt("AstroScore", 0);
            Application.Quit();
        }
        if(follow == true)
        {
            collectible.transform.position = collectibleloc.transform.position;
        }
        setScore();
    }

    private void setScore()
    {
        //score = PlayerPrefs.GetInt("AstroScore");
        text.text = score.ToString();
    }

    void Start()
    { 
        //setScore();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Collectible" && isHolding == false && !inZone.Contains(collider.gameObject))
        {
            follow = true;
            collectible = collider.gameObject;
            isHolding = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        if (collider.gameObject.tag == "Collectible" && EnemyScore.inZone.Contains(collider.gameObject))
        {
            EnemyScore.inZone.Remove(collider.gameObject);
            EnemyScore.score--;
            //EnemyScore.text.text = EnemyScore.score.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "EarthGround" && isHolding == true)
        {
            score++;
            //PlayerPrefs.SetInt("AstroScore", score);
            text.text = score.ToString();
            if (score == winScore)
            {
                Debug.Log("Astro Won");
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
