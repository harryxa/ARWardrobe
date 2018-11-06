using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //list of all audio for selected item
    public List<AudioClip> dressAudio = new List<AudioClip>();
    public List<AudioClip> becsAudio = new List<AudioClip>();


    public List<AudioClip> musicAudio = new List<AudioClip>();
    public List<AudioClip> selectedAudio = new List<AudioClip>();

    //list of hotspots in the scene, when hotspoty inits it adds to list
    public List<GameObject> hotSpots = new List<GameObject>();
    public AudioSource IntroOutroMusicSource;
    public AudioSource IntroOutroAudioSource;

    //int to indicate which audio from list to play
    int audioNumber;
    private bool introPlayed = false;

    public enum ItemChoice
    {
        NONE,
        BECS,
        DRESS        
    }

    public ItemChoice itemChoice;

	void Start ()
    {        
        audioNumber = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //select an Item, Play first Audio for Item

        if(introPlayed == false)
        {
            IntroOutroMusicSource.volume = 1f;
            if(!IntroOutroMusicSource.isPlaying)
                IntroOutroMusicSource.Play();
            ItemSelect();
        }
        if(IntroOutroAudioSource.isPlaying == false && introPlayed == true)
        {
            IntroOutroMusicSource.Stop();

            if (audioNumber < selectedAudio.Count)
                ActivateHotSpot();
            else
            {
                //return everything to start
                introPlayed = false;
                audioNumber = 0;
                itemChoice = ItemChoice.NONE;
                selectedAudio = null;
                for (int i = 0; i < hotSpots.Count; i++)
                {
                    hotSpots[i].SetActive(false);
                }
            }
        }
    }


    //selects appropriate audio for item selected
    private void ItemSelect()
    {
        switch (itemChoice)
        {
            case ItemChoice.NONE:
                break;

            case ItemChoice.DRESS:
                if (selectedAudio != dressAudio)
                {
                    selectedAudio = dressAudio;
                    //audioNumber = 0;
                    PlayFirstClip();
                }
                break;

            case ItemChoice.BECS:
                if (selectedAudio != becsAudio)
                {
                    selectedAudio = becsAudio;
                    //audioNumber = 0;
                    PlayFirstClip();
                }
                break;
        }
    }

    private void PlayFirstClip()
    {
        IntroOutroMusicSource.volume = 0.2f;
        IntroOutroAudioSource.clip = selectedAudio[audioNumber];
        IntroOutroAudioSource.Play();
        IncrementAudioNumber();
        introPlayed = true;
    }

    //all hotspots are initialised at start unactive
    //this activates them one at a time
    private void ActivateHotSpot()
    {                
        hotSpots[audioNumber - 1].SetActive(true);
    }    

    public AudioClip GetSelectedAudio()
    {     
        return selectedAudio[audioNumber];
    }

    public AudioClip GetSelectedMusicAudio()
    {
        return musicAudio[audioNumber - 1];
    }

    //incremented when leaving a hotspot
    public void IncrementAudioNumber()
    {
        audioNumber++;
    }

    public void AddToHotSpotList(GameObject hotspot)
    {
        hotSpots.Add(hotspot);
    }
}
