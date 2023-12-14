using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads the main game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //Closes the game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
