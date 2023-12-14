using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public void Start()
    {
        if (OptionSection.music)
        {
            audioSource.Play();
        }
    }
}
