using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void quitLeaderboard()
    {
        SceneManager.LoadScene(3);
    }
    public void goToLeaderboard()
    {
        SceneManager.LoadScene(4);
    }
}

