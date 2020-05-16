using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EndlessMode()
    {
        SceneManager.LoadScene("crafting_scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
