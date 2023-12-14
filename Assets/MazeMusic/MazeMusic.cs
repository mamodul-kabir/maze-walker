using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMusic : MonoBehaviour
{
    public AudioSource audioSource;
    void Start()
    {
        if (OptionSection.music)
        {
            audioSource.Play();
        }
    }
}
