using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject collectible;
    public Text text;
    public int score = 0;
    public int winScore = 5;
    public bool isHolding = false;
    public GameObject collectibleloc;
    bool follow = false;
    public List<GameObject> inZone = new List<GameObject>();
    public EnemyScore es;
    public bool steal = false;
    public PlayerController pc;
    public PlayerScore ps;
    public float WaitTime = 5f;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    private AudioSource audio;

    private void setScore()
    {
        //score = PlayerPrefs.GetInt("AstroScore");
        text.text = score.ToString();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            PlayerPrefs.SetInt("AstroRound", 0);
            Application.Quit();
        }
        if(follow == true)
        {
            collectible.transform.position = collectibleloc.transform.position;
        }
        if (steal == true)
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
        float temp = rb.gravityScale;
        pc.enabled = false;
        ps.enabled = false;
        bc.enabled = false;
        rb.gravityScale = 0;

        yield return new WaitForSeconds(WaitTime);

        rb.gravityScale = temp;
        bc.enabled = true;
        ps.enabled = true;
        pc.enabled = true;
    }

    void Start()
    {
        //setScore();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Collectible" && isHolding == false && !inZone.Contains(collider.gameObject))
        {
            audio.Play();
            follow = true;
            collectible = collider.gameObject;
            isHolding = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if(collider.gameObject == es.collectible)
            {
                Debug.Log("Stealing from Alien");
                es.steal = true;
                Debug.Log("Steal Value : " + es.steal);
            }
        }
        if (collider.gameObject.tag == "Collectible" && es.inZone.Contains(collider.gameObject))
        {
            audio.Play();
            es.inZone.Remove(collider.gameObject);
            es.score--;
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
            //if (score == winScore)
            //{
            //    Debug.Log("Astro Won");
            //    PlayerPrefs.SetInt("AstroRound", PlayerPrefs.GetInt("AstroRound")+1);
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //}
            inZone.Add(collectible);
            collectible = null;
            isHolding = false;
            follow = false;
        }
    }
}
