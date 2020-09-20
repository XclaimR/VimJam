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
    private int score = 0;

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            PlayerPrefs.SetInt("AstroScore", 0);
            Application.Quit();
        }
    }

    private void setScore()
    {
        score = PlayerPrefs.GetInt("AstroScore");
        text.text = score.ToString();
    }

    void Start()
    { 
        float spawnY = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 35)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height-35)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        Instantiate(collectible, spawnPosition, Quaternion.identity);
        setScore();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Collectible")
        {
            PlayerPrefs.SetInt("AstroScore", score + 1);
            Destroy(collider.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
