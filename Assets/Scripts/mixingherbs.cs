using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixingherbs : MonoBehaviour
{
    
    #region Singleton

    public static mixingherbs instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of mixingHerbs found.");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnMixingHerbs();
    public OnMixingHerbs OnMixingHerbsCallback;

    public int maxHerbCount = 3;
    public List<herbs> herbList = new List<herbs>();
    
    public void SelectHerb (herbs herb)
    {
        if (herbList.Count >= maxHerbCount)
        {
            Debug.Log("No more herbs can be selected.");
            return;
        }
        herbList.Add(herb);

        if (herbList.Count == 3 && OnMixingHerbsCallback != null)
            OnMixingHerbsCallback.Invoke();
    }

    public void RemoveHerb (herbs herb)
    {
        herbList.Remove(herb);
    }
}
