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
    public GameObject scoreCard;
    public GameObject Background;

    public Image patientDisplay;

    public Text patientCounterDisplay;
    public int patientCounter = 1;

    public GameObject RedoButton;

    Transform[] HerbList;

    mixingherbs mymixingherbs;
    PatientList mypatientlist;

    MixingHerbsSlot[] slotList;

    public elementBar waterBar;
    public elementBar fireBar;
    public elementBar airBar;

    [SerializeField]
    private AK.Wwise.Event myEvent = null;

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
        patientCounterDisplay.text = "Patient # " + patientCounter + "/10";
        if (patientCounter > 10)
        {
            scoreCard.SetActive(true);
            myEvent.Stop(Background.gameObject);
            AkSoundEngine.PostEvent("Score_Win", gameObject);
            return;
        }

        // Resetting Herbs on display
        for (int i = 0; i < HerbList.Length; i++)
        {
            HerbList[i].localScale = new Vector3(1f, 1f, 1f);
        }

        // Resetting Selected Herbs
        mymixingherbs.herbList.Clear();
        for (int i = 0; i < slotList.Length; i++)
            slotList[i].ClearSlot();

        // Resetting the Mix and Redo Button
        LeanTween.scale(RedoButton, Vector3.one, 0.2f);
        LeanTween.scale(gameObject, Vector3.zero, 0.2f).setOnComplete(OnComplete);

        // Introducing new Patient in UI
        patientDisplay.sprite = mypatientlist.nextPatient().sick;

        // Updating new Patient Stats
        Vector3 newPatient = mypatientlist.nextPatientStats();
        waterBar.SetBarValue(newPatient.x);
        fireBar.SetBarValue(newPatient.y);
        airBar.SetBarValue(newPatient.z);
    }

    public void OnComplete()
    {
        LeanTween.scale(doneButton, Vector3.one, 0.2f);
    }
}
