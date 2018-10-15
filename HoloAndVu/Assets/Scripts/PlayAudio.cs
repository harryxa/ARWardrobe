using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip dressAudio = new AudioClip();
    public AudioClip lipstickAudio = new AudioClip();
    public AudioClip shoesAudio = new AudioClip();

    private AudioSource m_AudioSource;

    public GameObject GameObjAudioManager;
    private AudioManager m_AudioManager;

    private bool soundPlayed = false;

    // Use this for initialization
    void Start ()
    {
        m_AudioSource = GetComponentInChildren<AudioSource>();
        m_AudioManager = GameObjAudioManager.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(m_AudioManager.isDress == true)
        {
            m_AudioSource.clip = dressAudio;            
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
        }
    }
}
