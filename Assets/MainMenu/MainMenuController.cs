using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class NewBehaviourScript : MonoBehaviour
{
    
    public void playGame()
    {
        SceneManager.LoadScene("MainGame"); 
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
