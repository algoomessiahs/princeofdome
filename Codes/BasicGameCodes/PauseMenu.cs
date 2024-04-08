using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public void Resume()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ReStart()
    {
        Time.timeScale = 1f;
        FindObjectOfType<SceneHandler>().LoadCurrentScene();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
