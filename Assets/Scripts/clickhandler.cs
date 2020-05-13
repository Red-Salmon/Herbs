using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickhandler : MonoBehaviour, IPointerDownHandler
{

    public herbs selectedHerb;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (mixingherbs.instance.SelectHerb(selectedHerb))
            LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.3f);
    }

}
