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

    public delegate void OnHerbSelected();
    public OnHerbSelected OnHerbSelectedCallback;

    public int maxHerbCount = 3;
    public List<herbs> herbList = new List<herbs>();
    
    public bool SelectHerb (herbs herb)
    {
        if (herbList.Count >= maxHerbCount)
        {
            Debug.Log("No more herbs can be selected.");
            return false;
        } else
        {
            herbList.Add(herb);

            if (OnHerbSelectedCallback != null)
                 OnHerbSelectedCallback.Invoke();

            return true;
        }
        
    }

    public void RemoveHerb (herbs herb)
    {
        herbList.Remove(herb);
    }

    public int WaterContent()
    {
        int total = 0;
        for (int i = 0; i < herbList.Count; i++)
            total += herbList[i].waterDelta;
        return total;
    }

    public int FireContent()
    {
        int total = 0;
        for (int i = 0; i < herbList.Count; i++)
            total += herbList[i].fireDelta;
        return total;
    }

    public int AirContent()
    {
        int total = 0;
        for (int i = 0; i < herbList.Count; i++)
            total += herbList[i].airDelta;
        return total;
    }
}
