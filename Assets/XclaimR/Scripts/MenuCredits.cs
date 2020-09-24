using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCredits : MonoBehaviour
{
    // Start is called before the first frame update
    public Text credits;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;

    void Start()
    {
        tempColor = credits.color;
        fontSize = credits.fontSize;
        audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        credits.fontSize = fontSize + 5;
        audio.Play();
    }

    void OnMouseExit()
    {
        credits.fontSize = fontSize;
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene("Credits");
    }
}
