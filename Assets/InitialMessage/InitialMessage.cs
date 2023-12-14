using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class InitialMessage : MonoBehaviour
{

    public GameObject message; 
    float startTime;
    private void Start()
    {
        if(PlayerDet.inChamber) message.SetActive(false);
        startTime = Time.time; 
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > 5.0f)
        {
            message.SetActive(false);
        }
        if (OVRInput.GetDown(OVRInput.Button.Three) && OVRInput.GetDown(OVRInput.Button.Four))
        {
            PlayerDet.inChamber = false; 
            PlayerDet.failed = false;
            PlayerDet.first = true; 
            SceneManager.LoadScene("MM");
        }
    }
}
