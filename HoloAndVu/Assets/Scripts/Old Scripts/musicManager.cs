using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    private AudioClip currentSong;
    public List<AudioClip> allSongs = new List<AudioClip>();
    //UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonScript;

    public AudioSource[] m_AudioSource;

    // Use this for initialization
    void Start ()
    {
        m_AudioSource = GetComponentsInChildren<AudioSource>();
        currentSong = allSongs[0];

    }

    // Update is called once per frame
    void Update()
    {        
        PlaySong();
        //when current song is over invoke method
        // Invoke("PlayNextTrack", currentSong.length / 16);

        if(m_AudioSource[1].isPlaying == false)
        {
            currentSong = allSongs[Random.Range(0, 4)];
        }
    }

    void PlaySong()
    {
        //for both audio sources
        for (int i = 0; i < m_AudioSource.Length; i++)
        {
            //if audio sources are not playing the current song, do so.
            if (m_AudioSource[i].clip != currentSong)
            {
                m_AudioSource[i].clip = currentSong;
                m_AudioSource[i].Play();
            }
        }
    }

    public void ChangeMusic(int i)
    {
        currentSong = allSongs[i];
    }
}
