using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool newGame;

    public void PlayGame()
    {
        SceneManager.LoadScene(""); // will change this to whatever our scene is called later
        newGame = true;
    }

    /*
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    */

    // function to close the game
    public void QuitGame()
    {
        Debug.Log("Exiting Game..."); // to show it works without needing to build
        Application.Quit(); // this only works once the game is built
    }
}

