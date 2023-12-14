using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    
    //If the player is in the maze chamber, set the static inchamber variable to true and 
    //run the maze chamber scene. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "OVRPlayerController")
        {
            PlayerDet.inChamber = true; 
            SceneManager.LoadScene("Riddle"); 
        }
    }
}
