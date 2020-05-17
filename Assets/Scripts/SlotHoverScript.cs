using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public herbs myherb = null;
    public Image infoCardDisplay;

    public void OnPointerEnter(PointerEventData eventData)
    {
            LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
            infoCardDisplay.sprite = myherb.infoCard;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.1f);
    }

    public void AssignHerb(herbs selectedHerb)
    {
        myherb = selectedHerb;
    }

    public void UnassignHerb()
    {
        myherb = null;
    }
}
