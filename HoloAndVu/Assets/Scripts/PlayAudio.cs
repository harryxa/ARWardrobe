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

    // Use this for initialization
    void Start ()
    {
        m_AudioSource = GetComponentInChildren<AudioSource>();

        GameObjAudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        m_AudioManager = GameObjAudioManager.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(m_AudioManager.itemChoice == AudioManager.ItemChoice.DRESS)
        {
            m_AudioSource.clip = m_AudioManager.GetSelectedAudio();            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera" && soundPlayed == false)
        {           
                soundPlayed = true;
                m_AudioSource.Play();            
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "MainCamera" && soundPlayed == true)
        {
            soundPlayed = false;
            Destroy(gameObject);
            m_AudioManager.IncrementAudioNumber();
            m_AudioManager.InstantiateNewAudioBubble();
        }
    }
}
