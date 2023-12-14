using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour
{
    //rerun the game or exit the game based on the player's choice. 
    public void mainMenu()
    {
        SceneManager.LoadScene("MM");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
