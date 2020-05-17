using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExpandOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image pointerSprite = null;

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
        if (pointerSprite != null)
            pointerSprite.transform.LeanMoveLocalY(gameObject.transform.localPosition.y - 5f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.1f);
    }
}
