using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource m_AudioSource;
    public AudioSource musicSource;

    public float loweredMusicVolume;
    private GameObject GameObjAudioManager;
    private AudioManager m_AudioManager;

    private bool soundPlayed = false;
    private bool incrementAudio = true;


    // Use this for initialization
    void Start ()
    {
        GameObjAudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        m_AudioManager = GameObjAudioManager.GetComponent<AudioManager>();
        m_AudioManager.AddToHotSpotList(this.gameObject);
        gameObject.SetActive(false);        
    }

    void Update()
    {
        if (!musicSource.clip)
        {
            musicSource.clip = m_AudioManager.GetSelectedMusicAudio();
            musicSource.Play();
        }
    }


    //When entering the trigger appropriate audio is selected and played.
    //Audio wont replay if entered again as SoundPlayed is true.
    private void OnTriggerEnter(Collider other)
    {    
        if (other.tag == "MainCamera" && soundPlayed == false && m_AudioManager.itemChoice != AudioManager.ItemChoice.NONE)
        {
            m_AudioSource.clip = m_AudioManager.GetSelectedAudio();
            musicSource.volume = loweredMusicVolume;
            soundPlayed = true;
            m_AudioSource.Play();
            
        }
    }

    //When exiting audio[] will be incremented once so next hotspot has correct Audio
    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "MainCamera" && soundPlayed == true && m_AudioManager.itemChoice != AudioManager.ItemChoice.NONE)
        {
            if(incrementAudio == true)
            {
                m_AudioManager.IncrementAudioNumber();
                incrementAudio = false;
            }

            musicSource.Stop();
        }

    }


}
