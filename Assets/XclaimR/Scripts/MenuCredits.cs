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

    void Start()
    {
        tempColor = credits.color;
        fontSize = credits.fontSize;
    }

    void OnMouseEnter()
    {
        credits.fontSize = fontSize + 5;
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
