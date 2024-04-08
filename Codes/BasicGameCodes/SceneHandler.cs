using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public Animator transtation;

    public float transatationTime = 1f;

    [SerializeField] float delayInSeconds = 2f;

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(sceneIndex + 1);
        StartCoroutine(LoadTranstation("Game"));
    }

    public void LoadCurrentScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(sceneIndex);
        StartCoroutine(LoadTranstation("Game"));
    }

    public void SetConfirmPanelActive(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void SetFalsePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadStartScreen()
    {
        //SceneManager.LoadScene(0);
        StartCoroutine(LoadTranstation("MainMenu"));
        Time.timeScale = 1f;
        Destroy(FindObjectOfType<Audio>().gameObject);
    }

    public void LoadWinner()
    {
        StartCoroutine(LoadTranstation("Winner"));
    }

    public void LoadProacticeScene()
    {
        StartCoroutine(LoadTranstation("SampleScene"));
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadOptions()
    {
        StartCoroutine(LoadTranstation("Options Menu"));
    }

    public void LoadOptionsNoTransation()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void LoadGame()
    {
        StartCoroutine(LoadTranstation("Game"));
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        StartCoroutine(LoadTranstation("Game Over"));
    }

    IEnumerator LoadTranstation(string levelName)
    {
        transtation.SetTrigger("Start");

        yield return new WaitForSeconds(transatationTime);

        SceneManager.LoadScene(levelName);
    }
}
