using UnityEngine;
using UnityEngine.UI;

public class MixingHerbsSlot : MonoBehaviour
{
    public Image icon;
    herbs herb;

    public void NewSelection(herbs newherb)
    {
        herb = newherb;

        icon.sprite = herb.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        herb = null;

        icon.sprite = null;
        icon.enabled = false;
    }
}
