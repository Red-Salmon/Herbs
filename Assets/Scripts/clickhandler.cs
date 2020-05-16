using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class clickhandler : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    public herbs selectedHerb;
    public Image infoCardDisplay;

    public bool selected = false;

    public void Start()
    {
        gameObject.GetComponent<Image>().sprite = selectedHerb.icon;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (mixingherbs.instance.SelectHerb(selectedHerb) && selected == false)
        {
            selected = true;
            LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.3f).setOnComplete(OnComplete);
        }
    }

    public void OnComplete()
    {
        selected = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selected == false)
        {
            LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
            infoCardDisplay.sprite = selectedHerb.infoCard;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected == false)
            LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.1f);
    }
}
