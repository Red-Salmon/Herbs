using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientList : MonoBehaviour
{
    #region Singleton

    public static PatientList instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PatientList found.");
            return;
        }
        instance = this;
    }

    #endregion

    public List<patient> completePatientList;
    public patient currentPatient;

    public void Start()
    {
        currentPatient = completePatientList[0];
    }

    public patient nextPatient()
    {
        currentPatient = completePatientList[Random.Range(0, completePatientList.Count)];
        return currentPatient;
    }
}
