using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShortcutKeys : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("crafting_scene");
        } else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainmenu_scene");
        }
    }
}
