using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NPC_SoundFX : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    AudioClip runningFX;
    [SerializeField]
    AudioClip hitFx;
    [SerializeField]
    bool isPlayerSoundChanges=true;
    #endregion
    #region Fields
    AudioSource playerAudioSource;
    #endregion

    #region Unity Methods
    private void Start()
    {
        playerAudioSource = this.GetComponent<AudioSource>();
        EventManager.OnGameFail.AddListener(this.PlayDeadSoundFx);
        EventManager.OnGameSuccess.AddListener(this.MuteSounds);
        EventManager.OnGameStarted.AddListener(this.PlayRunSoundFx);
        if (isPlayerSoundChanges)
        {
            EventManager.OnFasterButtonPressed.AddListener(this.FastRunSpeed);
            EventManager.OnSlowDownButtonPressed.AddListener(this.SlowRunSpeed);
        }
    }
    #endregion
    #region Private Methods
    void PlayDeadSoundFx()
    {
        this.playerAudioSource.loop = false;
        this.playerAudioSource.PlayOneShot(hitFx);
    }
    void PlayRunSoundFx()
    {
        this.playerAudioSource.clip = runningFX;
        this.playerAudioSource.loop = true;
        
        this.playerAudioSource.Play();
        
    }
    void MuteSounds()
    {
        this.playerAudioSource.mute = true;
    }
    void FastRunSpeed()
    {
        this.playerAudioSource.pitch = 2;
    }
    void SlowRunSpeed()
    {
        this.playerAudioSource.pitch = 0.5F;
    }

    #endregion


}
