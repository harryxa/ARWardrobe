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

    //int to indicate which audio from list to play
    int audioNumber;

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
        ItemSelect();
        ActivateHotSpot();        
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
                    selectedAudio = dressAudio;
                break;

            case ItemChoice.BECS:
                if (selectedAudio != becsAudio)
                    selectedAudio = becsAudio;
                break;
        }
    }
    
    //all hotspots are initialised at start unactive
    //this activates them one at a time
    private void ActivateHotSpot()
    {
        for (int i = 0; i < hotSpots.Count; i++)
        {
            if (!hotSpots[i].activeSelf && audioNumber == i)
            {
                hotSpots[i].SetActive(true);
            }
        }
    }    

    public AudioClip GetSelectedAudio()
    {     
        return selectedAudio[audioNumber];
    }

    public AudioClip GetSelectedMusicAudio()
    {
        return musicAudio[audioNumber];
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
