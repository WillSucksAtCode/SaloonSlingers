using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("FullScene");
    }

    // function to close the game
    public void QuitGame()
    {
        Debug.Log("Exiting Game..."); // to show it works without needing to build
        Application.Quit(); // this only works once the game is built
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

