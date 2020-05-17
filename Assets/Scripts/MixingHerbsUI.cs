using UnityEngine;

public class MixingHerbsUI : MonoBehaviour
{
    public Transform slotsContainer;

    mixingherbs mymixingherbs;
    MixingHerbsSlot[] slots;
    SlotHoverScript[] herbList;

    void Start()
    {
        mymixingherbs = mixingherbs.instance;
        mymixingherbs.OnHerbSelectedCallback += UpdateUI;

        slots = slotsContainer.GetComponentsInChildren<MixingHerbsSlot>();
        herbList = slotsContainer.GetComponentsInChildren<SlotHoverScript>();
    }

    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI!");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < mymixingherbs.herbList.Count)
            {
                slots[i].NewSelection(mymixingherbs.herbList[i]);
                herbList[i].AssignHerb(mymixingherbs.herbList[i]);
            } else
            {
                slots[i].ClearSlot();
                herbList[i].UnassignHerb();
            }
        }
        
    }
}
