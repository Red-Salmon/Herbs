using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCardScript : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("crafting_scene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu_scene");
    }
}
