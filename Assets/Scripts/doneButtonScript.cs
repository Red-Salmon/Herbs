using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class doneButtonScript : MonoBehaviour, IPointerDownHandler
{
    mixingherbs mymixingherbs;
    PatientList mypatientlist;

    public GameObject nextButton;

    public GameObject patientDisplay;

    public elementBar waterBar;
    public elementBar fireBar;
    public elementBar airBar;

    void Start()
    {
        mymixingherbs = mixingherbs.instance;
        mypatientlist = PatientList.instance;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        DoneButtonPress();
    }

    void DoneButtonPress()
    {
        if (mymixingherbs.herbList.Count == 3)
        {
            // Updating bar levels
            waterBar.SetBarValue(waterBar.BarValue() + mymixingherbs.WaterContent());
            fireBar.SetBarValue(fireBar.BarValue() + mymixingherbs.FireContent());
            airBar.SetBarValue(airBar.BarValue() + mymixingherbs.AirContent());

            // Replacing the done button
            LeanTween.scale(gameObject, Vector3.zero, 0.2f).setOnComplete(OnComplete);

            // Evaluating success or failure
            if (waterBar.BarValue() == 5 && fireBar.BarValue() == 5 && airBar.BarValue() == 5)
            {
                // Success
                patientDisplay.GetComponent<Image>().sprite = mypatientlist.currentPatient.healthy;
                LeanTween.moveLocalY(patientDisplay, 1f, 0.3f).setLoopPingPong(1);
            } else
            {
                // Failure
                LeanTween.scaleY(patientDisplay, 0.2f, 0.3f).setLoopPingPong(1);
                LeanTween.moveLocalY(patientDisplay, -1f, 0.3f).setLoopPingPong(1);
            }
        }
    }

    public void OnComplete()
    {
        LeanTween.scale(nextButton, Vector3.one, 0.2f);
    }
}
