using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    //If player is in range, then load the ending scene. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "OVRPlayerController")
        {
            SceneManager.LoadScene("EndingMenu");
        }
    }
}
