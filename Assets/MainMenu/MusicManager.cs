using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (OptionSection.music)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (audioSource.isPlaying && !OptionSection.music)
        {
            audioSource.Stop();
        }else if(!audioSource.isPlaying && OptionSection.music)
        {
            audioSource.Play();
        }
    }
}
