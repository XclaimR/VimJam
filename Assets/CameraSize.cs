using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cameraOutput;

    void Start()
    {
        Debug.Log("Pixel width :" + cameraOutput.pixelWidth + " Pixel height : " + cameraOutput.pixelHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
