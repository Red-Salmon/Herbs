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
    public Vector3 patientStats = new Vector3(4f, 7f, 7f);

    public void Start()
    {
        currentPatient = completePatientList[0];
    }

    public patient nextPatient()
    {
        // Ensuring that the new patient is different from the last
        patient newPatient = currentPatient;
        while (newPatient == currentPatient)
        {
            newPatient = completePatientList[Random.Range(0, completePatientList.Count)];
        }
        currentPatient = newPatient;
        return currentPatient;
    }

    public Vector3 nextPatientStats(int HerbListLength)
    {
        // Generating new Patient Stats, ensuring that the new stats are different from the current one
        Vector3 newPatient = patientStats;
        while (newPatient == patientStats)
        {
            newPatient = RandomPatientStats(HerbListLength);
        }
        patientStats = newPatient;
        return patientStats;
    }

    Vector3 RandomPatientStats(int HerbCount)
    {
        if (HerbCount == 4)
        {
            switch (Random.Range(1, 5))
            {
                // Level 1: 4 possible combinations with 4 herbs
                case 1: return new Vector3(4f, 7f, 7f);
                case 2: return new Vector3(5f, 9f, 7f);
                case 3: return new Vector3(5f, 7f, 9f);
                case 4: return new Vector3(3f, 9f, 9f);
                default: return new Vector3(0f, 0f, 0f);
            }
        }
        else if (HerbCount == 6)
        {
            switch (Random.Range(1, 21))
            {
                // Level 2: 20 possible combinations with 6 herbs
                case 1: return new Vector3(4f, 7f, 7f);
                case 2: return new Vector3(5f, 9f, 7f);
                case 3: return new Vector3(5f, 7f, 9f);
                case 4: return new Vector3(3f, 9f, 9f);
                case 5: return new Vector3(7f, 7f, 5f);
                case 6: return new Vector3(3f, 5f, 3f);
                case 7: return new Vector3(7f, 5f, 7f);
                case 8: return new Vector3(3f, 3f, 5f);
                case 9: return new Vector3(8f, 7f, 7f);
                case 10: return new Vector3(4f, 5f, 5f);
                case 11: return new Vector3(6f, 3f, 3f);
                case 12: return new Vector3(5f, 7f, 7f);
                case 13: return new Vector3(1f, 5f, 5f);
                case 14: return new Vector3(6f, 9f, 7f);
                case 15: return new Vector3(2f, 7f, 5f);
                case 16: return new Vector3(4f, 5f, 3f);
                case 17: return new Vector3(6f, 7f, 9f);
                case 18: return new Vector3(2f, 5f, 7f);
                case 19: return new Vector3(4f, 3f, 5f);
                case 20: return new Vector3(4f, 3f, 5f);
                default: return new Vector3(0f, 0f, 0f);
            }
        }
        else
        {
            return new Vector3(0f, 0f, 0f);
        }
    }
}
