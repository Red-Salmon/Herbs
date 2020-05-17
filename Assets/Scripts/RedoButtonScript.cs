using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RedoButtonScript : MonoBehaviour, IPointerDownHandler
{
    mixingherbs mymixingherbs;

    public Transform herbsContainer;
    public Transform slotsContainer;

    Transform[] HerbList;
    MixingHerbsSlot[] slotList;

    public void Start()
    {
        mymixingherbs = mixingherbs.instance;

        HerbList = herbsContainer.GetComponentsInChildren<Transform>();
        slotList = slotsContainer.GetComponentsInChildren<MixingHerbsSlot>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Resetting Herbs on display
        for (int i = 0; i < HerbList.Length; i++)
        {
            HerbList[i].localScale = new Vector3(1f, 1f, 1f);
        }

        // Resetting Selected Herbs
        mymixingherbs.herbList.Clear();
        for (int i = 0; i < slotList.Length; i++)
            slotList[i].ClearSlot();
    }
}
