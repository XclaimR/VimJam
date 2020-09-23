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

    void Start()
    {
        tempColor = back.color;
        fontSize = back.fontSize;
    }

    void OnMouseEnter()
    {
        back.fontSize = fontSize + 5;
    }

    void OnMouseExit()
    {
        back.fontSize = fontSize;
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
