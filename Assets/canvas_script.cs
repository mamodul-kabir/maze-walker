using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMapTrigger : MonoBehaviour
{
    public Canvas mmapCanvas;
    private bool isMapShown = false;

    private void Start()
    {
        mmapCanvas.enabled = false; 
    }
    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            isMapShown = !isMapShown;
            mmapCanvas.enabled = isMapShown;
        }
    }
}
