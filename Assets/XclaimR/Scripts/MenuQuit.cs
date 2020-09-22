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

    void Start()
    {
        tempColor = quit.color;
        fontSize = quit.fontSize;
    }

    void OnMouseEnter()
    {
        quit.fontSize = fontSize + 5;
    }

    void OnMouseExit()
    {
        quit.fontSize = fontSize;
    }

    void OnMouseUp()
    {
        Application.Quit();
    }
}
