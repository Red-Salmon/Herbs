using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextPatientScript : MonoBehaviour, IPointerDownHandler
{
    public Transform herbsContainer;
    public Transform slotsContainer;
    public GameObject doneButton;

    public Image patientDisplay;

    public Text patientCounterDisplay;
    int patientCounter = 1;

    Transform[] HerbList;

    mixingherbs mymixingherbs;
    PatientList mypatientlist;

    MixingHerbsSlot[] slotList;

    public elementBar waterBar;
    public elementBar fireBar;
    public elementBar airBar;

    public void Start()
    {
        gameObject.transform.localScale = Vector3.zero;

        mymixingherbs = mixingherbs.instance;
        mypatientlist = PatientList.instance;

        HerbList = herbsContainer.GetComponentsInChildren<Transform>();
        slotList = slotsContainer.GetComponentsInChildren<MixingHerbsSlot>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked on the next patient button");

        // Updating the Patient Counter
        patientCounter++;
        patientCounterDisplay.text = "Patient # " + patientCounter;

        // Resetting Herbs on display
        for (int i = 0; i < HerbList.Length; i++)
        {
            HerbList[i].localScale = new Vector3(1f, 1f, 1f);
        }

        // Resetting Selected Herbs
        mymixingherbs.herbList.Clear();
        for (int i = 0; i < slotList.Length; i++)
            slotList[i].ClearSlot();

        // Resetting the Mix Button
        LeanTween.scale(gameObject, Vector3.zero, 0.2f).setOnComplete(OnComplete);

        // Introducing new Patient in UI
        patientDisplay.sprite = mypatientlist.nextPatient().sick;

        // Updating new Patient Stats
        Vector3 newPatient = RandomPatientStats(4);
        waterBar.SetBarValue(newPatient.x);
        fireBar.SetBarValue(newPatient.y);
        airBar.SetBarValue(newPatient.z);
    }

    Vector3 RandomPatientStats(int HerbCount)
    {
        if (HerbCount == 4)
        {
            switch (Random.Range(1, 5))
            {
                // Level 1: 4 possible combinations with 4 herbs
                case 1: return new Vector3(4f, 7f, 7f);
                case 2: return new Vector3(5f, 9f, 7f);
                case 3: return new Vector3(5f, 7f, 9f);
                case 4: return new Vector3(3f, 9f, 9f);
                default: return new Vector3(0f, 0f, 0f);
            }
        } else if (HerbCount == 6)
        {
            switch (Random.Range(1, 21))
            {
                // Level 2: 20 possible combinations with 6 herbs
                case 1: return new Vector3(4f, 7f, 7f);
                case 2: return new Vector3(5f, 9f, 7f);
                case 3: return new Vector3(5f, 7f, 9f);
                case 4: return new Vector3(3f, 9f, 9f);
                case 5: return new Vector3(7f, 7f, 5f);
                case 6: return new Vector3(3f, 5f, 3f);
                case 7: return new Vector3(7f, 5f, 7f);
                case 8: return new Vector3(3f, 3f, 5f);
                case 9: return new Vector3(8f, 7f, 7f);
                case 10: return new Vector3(4f, 5f, 5f);
                case 11: return new Vector3(6f, 3f, 3f);
                case 12: return new Vector3(5f, 7f, 7f);
                case 13: return new Vector3(1f, 5f, 5f);
                case 14: return new Vector3(6f, 9f, 7f);
                case 15: return new Vector3(2f, 7f, 5f);
                case 16: return new Vector3(4f, 5f, 3f);
                case 17: return new Vector3(6f, 7f, 9f);
                case 18: return new Vector3(2f, 5f, 7f);
                case 19: return new Vector3(4f, 3f, 5f);
                case 20: return new Vector3(4f, 3f, 5f);
                default: return new Vector3(0f, 0f, 0f);
            }
        } else
        {
            return new Vector3(0f, 0f, 0f);
        }
    }

    public void OnComplete()
    {
        LeanTween.scale(doneButton, Vector3.one, 0.2f);
    }
}
