using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class doneButtonScript : MonoBehaviour, IPointerDownHandler
{
    mixingherbs mymixingherbs;

    public elementBar waterBar;
    public elementBar fireBar;
    public elementBar airBar;

    void Start()
    {
        mymixingherbs = mixingherbs.instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked on the done button");
        DoneButtonPress();
    }

    void DoneButtonPress()
    {
        if (mymixingherbs.herbList.Count == 3)
        {
            waterBar.SetBarValue(waterBar.BarValue() + mymixingherbs.WaterContent());
            fireBar.SetBarValue(fireBar.BarValue() + mymixingherbs.FireContent());
            airBar.SetBarValue(airBar.BarValue() + mymixingherbs.AirContent());
        }
    }
}
