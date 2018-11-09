using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //list of all audio for selected item
    public List<AudioClip> becsAudio = new List<AudioClip>();
    public List<AudioClip> micahAudio = new List<AudioClip>();
    public List<AudioClip> jamieAudio = new List<AudioClip>();
    public List<AudioClip> selectedAudio = new List<AudioClip>();



    public List<AudioClip> becsMusic = new List<AudioClip>();
    public List<AudioClip> micahsMusic = new List<AudioClip>();
    public List<AudioClip> jamiesMusic = new List<AudioClip>();
    public List<AudioClip> IntroOutroMusic = new List<AudioClip>();
    public List<AudioClip> selectedMusic = new List<AudioClip>();


    public TextMesh DebugDisplay;

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
        MICAH,
        JAMIE,
        FINISH
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
                IntroOutroMusicSource.clip = IntroOutroMusic[0];
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
                PlayOutro();
                introPlayed = false;
                audioNumber = 0;
                itemChoice = ItemChoice.NONE;
                selectedAudio = null;
                selectedMusic = null;
                
                DebugDisplay = null;
                              
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

            case ItemChoice.BECS:
                if (selectedAudio != becsAudio)
                {
                    selectedAudio = becsAudio;
                    selectedMusic = becsMusic;
                }
                break;

            case ItemChoice.MICAH:
                if (selectedAudio != micahAudio)
                {
                    selectedAudio = micahAudio;
                    selectedMusic = micahsMusic;
                }
                break;

            case ItemChoice.JAMIE:
                if (selectedAudio != jamieAudio)
                {
                    selectedAudio = jamieAudio;
                    selectedMusic = jamiesMusic;
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
        return selectedMusic[audioNumber - 1];
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

    public void PlayOutro()
    {
        IntroOutroMusicSource.clip = IntroOutroMusic[1];
        IntroOutroMusicSource.Play();
        DebugDisplay.text = "Please retun the Headset.";

    }
}
