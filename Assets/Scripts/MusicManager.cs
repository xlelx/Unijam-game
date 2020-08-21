using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip newMusic;
    void Awake ()
     {
         
          GameObject go = GameObject.Find("GameMusic");
           //Finds the game object called Game Music, if it goes by a different name, change this.
          go.GetComponent<AudioSource>().clip = newMusic; //Replaces the old audio with the new one set in the inspector.
          go.GetComponent<AudioSource>().Play(); //Plays the audio.
     }
}
