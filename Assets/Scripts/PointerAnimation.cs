using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerAnimation : MonoBehaviour
{
    public float animationDuration = 0.9f;
    public float animationDistance = 5f;

    void Start()
    {
        LeanTween.moveLocalY(gameObject, animationDistance, animationDuration).setLoopPingPong();
    }

    
}
