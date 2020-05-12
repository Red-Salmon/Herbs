using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickhandler : MonoBehaviour, IPointerDownHandler
{

    public herbs selectedHerb;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Clicked on " + selectedHerb.herbName);
        if (mixingherbs.instance.SelectHerb(selectedHerb))
            LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.2f);
    }

}
