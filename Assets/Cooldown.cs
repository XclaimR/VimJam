using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void SetMaxValue(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }

    public void SetCoolDown(float value)
    {
        slider.value = value;
    }
}
