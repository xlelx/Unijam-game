using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;

    private float musicVolume = 0.5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }

    public void setVolume(float vol){
        musicVolume = vol;
    }
}
