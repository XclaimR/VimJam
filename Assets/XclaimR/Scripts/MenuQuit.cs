using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuQuit : MonoBehaviour
{
    // Start is called before the first frame update
    public Text quit;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;

    void Start()
    {
        tempColor = quit.color;
        fontSize = quit.fontSize;
        audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        quit.fontSize = fontSize + 5;
        audio.Play();
    }

    void OnMouseExit()
    {
        quit.fontSize = fontSize;
    }

    void OnMouseUp()
    {
        Application.OpenURL("https://xclaimr.itch.io/comet-me-bro");
    }
}
