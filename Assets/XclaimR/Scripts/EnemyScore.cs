using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EnemyScore : MonoBehaviour
{
    public GameObject collectible;
    public Text text;
    public int score = 0;
    public int winScore = 5;
    public bool isHolding = false;
    public GameObject collectibleloc;
    public bool follow = false;
    public List<GameObject> inZone = new List<GameObject>();
    public PlayerScore ps;
    public bool steal = false;
    public EnemyController ec;
    public EnemyScore es;
    public float WaitTime = 5f;
    //public Rigidbody2D rb;

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
        if(steal == true)
        {
            isHolding = false;
            follow = false;
            collectible = null;
            steal = false;
            StartCoroutine("StunScript");
        }
        setScore();
    }

    IEnumerator StunScript()
    {
        ec.enabled = false;
        es.enabled = false;
        //rb.enabled = false;

        yield return new WaitForSeconds(WaitTime);

        //rb.enabled = true;
        es.enabled = true;
        ec.enabled = true;
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
            if (collider.gameObject == ps.collectible)
            {
                //Debug.Log("Stealing from Astro");
                ps.steal = true;
                //Debug.Log("Steal Value : " + ps.steal);
            }
        }
        if (collider.gameObject.tag == "Collectible" && ps.inZone.Contains(collider.gameObject))
        {
            ps.inZone.Remove(collider.gameObject);
            ps.score--;
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
