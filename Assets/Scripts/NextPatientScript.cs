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
        Vector3 newPatient = RandomPatient(4);
        waterBar.SetBarValue(newPatient.x);
        fireBar.SetBarValue(newPatient.y);
        airBar.SetBarValue(newPatient.z);
    }

    Vector3 RandomPatient(int HerbCount)
    {
        if (HerbCount == 4)
        {
            switch (Random.Range(1, 5))
            {
                case 1: return new Vector3(4f, 8f, 9f);
                case 2: return new Vector3(3f, 6f, 3f);
                case 3: return new Vector3(3f, 3f, 7f);
                case 4: return new Vector3(1f, 6f, 7f);
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
