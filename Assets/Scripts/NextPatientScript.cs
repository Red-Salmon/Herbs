using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NextPatientScript : MonoBehaviour, IPointerDownHandler
{
    public Transform herbsContainer;
    public Transform slotsContainer;

    public Text patientCounterDisplay;
    public int patientCounter = 1;

    Transform[] HerbList;

    mixingherbs mymixingherbs;

    MixingHerbsSlot[] slotList;

    public void Start()
    {
        mymixingherbs = mixingherbs.instance;
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
            HerbList[i].localScale = new Vector3(1f, 1f, 1f);

        // Resetting Selected Herbs
        mymixingherbs.herbList.Clear();
        for (int i = 0; i < slotList.Length; i++)
            slotList[i].ClearSlot();

        // Introducing new Patient

    }
}
