using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private GameObject GameObjAudioManager;
    private AudioManager m_AudioManager;

    private bool soundPlayed = false;
    private bool incrementAudio = true;


    // Use this for initialization
    void Start ()
    {
        m_AudioSource = GetComponentInChildren<AudioSource>();

        GameObjAudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        m_AudioManager = GameObjAudioManager.GetComponent<AudioManager>();
        m_AudioManager.AddToHotSpotList(this.gameObject);
        //gameObject.GetComponentInChildren<Transform>().localScale = new Vector3(2, 2, 2);
    }

    //When entering the trigger appropriate audio is selected and played.
    //Audio wont replay if entered again as SoundPlayed is true.
    private void OnTriggerEnter(Collider other)
    {    
        if (other.tag == "MainCamera" && soundPlayed == false)
        {
            if (m_AudioManager.itemChoice == AudioManager.ItemChoice.DRESS)
            {
                m_AudioSource.clip = m_AudioManager.GetSelectedAudio();
            }

            soundPlayed = true;
            m_AudioSource.Play();
            
        }
    }

    //When exiting audio[] will be incremented once so next hotspot has correct Audio
    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "MainCamera" && soundPlayed == true)
        {
            if(incrementAudio == true)
            {
                m_AudioManager.IncrementAudioNumber();
                incrementAudio = false;
            }
        }
    }


}
