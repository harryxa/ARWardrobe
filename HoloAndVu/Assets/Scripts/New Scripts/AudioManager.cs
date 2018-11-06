using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //list of all audio for selected item
    public List<AudioClip> dressAudio = new List<AudioClip>();
    public List<AudioClip> becsAudio = new List<AudioClip>();
    public List<AudioClip> selectedAudio = new List<AudioClip>();

    public List<AudioClip> musicAudio = new List<AudioClip>();

    //list of hotspots in the scene, when hotspot inits it adds to list
    public List<GameObject> hotSpots = new List<GameObject>();

    public AudioSource IntroOutroMusicSource;
    public AudioSource IntroOutroAudioSource;

    //int indicates which audio from list to play
    public int audioNumber;
    private bool introPlayed;

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
        introPlayed = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (introPlayed == false)
        {
            //Plays intro music
            if(!IntroOutroMusicSource.isPlaying)
            {
                IntroOutroMusicSource.volume = 1f;
                IntroOutroMusicSource.Play();
            }

            //Selects clothing item and gets appropriate audio for hotspots            
            ItemSelect();

            //Plays intro clip, sets introPlayed to true and increments audio number
            if (itemChoice != ItemChoice.NONE)
                PlayFirstClip();
        }
        //if intro clip has stopped and first clip has played
        else if(IntroOutroAudioSource.isPlaying == false && introPlayed == true)
        {
            IntroOutroMusicSource.Stop();

            //activate hotspots when required
            if (audioNumber < selectedAudio.Count)
            {
                ActivateHotSpot();
            }
            //if no more audio clips to play restart
            else
            {                
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
                }
                break;

            case ItemChoice.BECS:
                if (selectedAudio != becsAudio)
                {
                    selectedAudio = becsAudio;
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
