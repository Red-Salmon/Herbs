using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class elementBar : MonoBehaviour
{
    public Slider mySlider;

    public void SetBarValue(float newBarLevel)
    {
        mySlider.value = newBarLevel;
    }

    public float BarValue()
    {
        return mySlider.value;
    }
}
