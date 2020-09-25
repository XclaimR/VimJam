using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsBack : MonoBehaviour
{
    // Start is called before the first frame update
    public Text back;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;

    void Start()
    {
        tempColor = back.color;
        fontSize = back.fontSize;
        audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        back.fontSize = fontSize + 5;
        audio.Play();
    }

    void OnMouseExit()
    {
        back.fontSize = fontSize;
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene(Random.Range(1, 4));
    }
}
