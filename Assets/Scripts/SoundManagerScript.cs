using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioClip walkSound, pushSound, jumpSound, jumpPadSound, clickSound, portalSound, collectSound;

    private static SoundManagerScript instance;

    private static ArrayList currentClips = new ArrayList();
    public static SoundManagerScript GetInstance()
    {
        return instance;
    }

    private static AudioSource audioSource;
    void Start()
    {
        walkSound = Resources.Load<AudioClip>("walk");
        pushSound = Resources.Load<AudioClip>("push");
        jumpSound = Resources.Load<AudioClip>("jump");
        jumpPadSound = Resources.Load<AudioClip>("jumpPad");
        clickSound = Resources.Load<AudioClip>("click");
        portalSound = Resources.Load<AudioClip>("portal");
        collectSound = Resources.Load<AudioClip>("collect");


        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (audioSource.isPlaying == false)
        {
            currentClips = new ArrayList();
        }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    public static void PlaySound(string clip)
    {
        if (!currentClips.Contains(clip))
        {
            currentClips.Add(clip);
            switch (clip)
            {
                case "walk":
                    audioSource.PlayOneShot(walkSound);
                    break;
                case "push":
                    audioSource.PlayOneShot(pushSound);
                    break;
                case "jump":
                    audioSource.PlayOneShot(jumpSound);
                    break;
                case "jumpPad":
                    audioSource.PlayOneShot(jumpPadSound);
                    break;
                case "click":
                    audioSource.PlayOneShot(clickSound);
                    break;
                case "portal":
                    audioSource.PlayOneShot(portalSound);
                    break;
                case "collect":
                    audioSource.PlayOneShot(collectSound);
                    break;
            }

        }

    }

    public void Click()
    {
        if (!currentClips.Contains("click"))
        {
            currentClips.Add("click");
            audioSource.PlayOneShot(clickSound);
        }
    }
}
