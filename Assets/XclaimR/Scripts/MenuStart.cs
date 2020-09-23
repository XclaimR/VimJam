using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public Text start;
    private int fontSize;
    private Color tempColor;

    void Start()
    {
        tempColor = start.color;
        fontSize = start.fontSize;
    }

    void OnMouseEnter()
    {
        start.fontSize = fontSize + 5;
    }

    void OnMouseExit()
    {
        start.fontSize = fontSize;
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
