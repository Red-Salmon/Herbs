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

    public Text scoreDisplay;

    public GameObject RedoButton;

    public elementBar waterBar;
    public elementBar fireBar;
    public elementBar airBar;

    public int Score = 0;
   
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
            StartCoroutine(myDelay());

            // Replacing the done button
            LeanTween.scale(gameObject, Vector3.zero, 0.2f);

            // Hiding the redo button
            LeanTween.scale(RedoButton, Vector3.zero, 0.2f);

            // Set a delay timer of 2.5 seconds
            IEnumerator myDelay()
            {
                yield return new WaitForSeconds(2.5f);
                // Evaluating success or failure
                if (waterBar.BarValue() == 5 && fireBar.BarValue() == 5 && airBar.BarValue() == 5)
                {
                    // Success
                    patientDisplay.GetComponent<Image>().sprite = mypatientlist.currentPatient.healthy;
                    LeanTween.moveLocalY(patientDisplay, 1f, 0.3f).setLoopPingPong(1).setOnComplete(OnComplete);
                    AkSoundEngine.PostEvent("OnSuccess", gameObject);
                    Score++;
                }
                else
                {
                    // Failure
                    LeanTween.scaleY(patientDisplay, 0.2f, 0.3f).setLoopPingPong(1);
                    LeanTween.moveLocalY(patientDisplay, -1f, 0.3f).setLoopPingPong(1).setOnComplete(OnComplete);
                    AkSoundEngine.PostEvent("OnFailure", gameObject);
                }
            }

            // Updating the Score
            scoreDisplay.text = Score.ToString() + " / 10";
        }
    }

    public void OnComplete()
    {
        LeanTween.scale(nextButton, Vector3.one, 0.2f);
    }
}
