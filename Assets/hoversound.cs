using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoversound : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event myEvent = null;

    public void OnMouseEnter()
    {
        Debug.Log("Mouse is over GameObject.");
        myEvent.Post(gameObject);
    }

}
