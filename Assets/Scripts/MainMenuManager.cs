using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
   public GameObject CreditsPanel;
    public void LoadPlayScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgainLoad()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void CreditsOpen()
    {
        CreditsPanel.SetActive(true);
    }
    public void CreditsQuit()
    {
        CreditsPanel.SetActive(false);
    }
}
