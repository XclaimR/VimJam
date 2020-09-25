using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHowToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text howtoplay;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;

    void Start()
    {
        tempColor = howtoplay.color;
        fontSize = howtoplay.fontSize;
        audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        howtoplay.fontSize = fontSize + 5;
        audio.Play();
    }

    void OnMouseExit()
    {
        howtoplay.fontSize = fontSize;
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene(Random.Range(1,4));
    }
}
