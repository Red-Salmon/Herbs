using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selecttoolmovement : MonoBehaviour
{
    public Transform selecttool;
    public float jumpSize;

    int gridx = 1;
    int gridy = 4;
    Vector3 displacement;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && gridy < 4)
        {
            gridy++;
            displacement = new Vector3(0f, 1f, 0f);
        } else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && gridy > 1)
        {
            gridy--;
            displacement = new Vector3(0f, -1f, 0f);
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && gridx > 1)
        {
            gridx--;
            displacement = new Vector3(-1f, 0f, 0f);
        }
        else if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && gridx < 4)
        {
            gridx++;
            displacement = new Vector3(1f, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.RightShift))
        {
            //Selecting the herb

        }
        else
        {
            displacement = new Vector3(0f, 0f, 0f);
        }

        // Updating the select tool's position if necessary
        selecttool.position += displacement * jumpSize;
    }
}
