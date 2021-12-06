using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : SingletonCreator<AudioManager>
{
    // Start is called before the first frame update
    [SerializeField]
    AudioClip fasterSpeed;
    [SerializeField]
    AudioClip slowerSpeed;

    AudioSource audiosrc;

    private void Start()
    {
        EventManager.OnFasterButtonPressed.AddListener(this.PlayFastSound);
        EventManager.OnSlowDownButtonPressed.AddListener(this.PlaySlowSound);
       this.audiosrc=  this.GetComponent<AudioSource>();
    }

    void PlayFastSound()
    {
        this.audiosrc.PlayOneShot(fasterSpeed);
    
    }
    void PlaySlowSound()
    {
        this.audiosrc.PlayOneShot(slowerSpeed);
    }

}
