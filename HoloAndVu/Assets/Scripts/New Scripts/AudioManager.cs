using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //list of all audio for selected item
    public List<AudioClip> dressAudio = new List<AudioClip>();
    public List<AudioClip> lipstickAudio = new List<AudioClip>();
    public List<AudioClip> shoeAudio = new List<AudioClip>();
    public List<AudioClip> selectedAudio = new List<AudioClip>();

    //list of hotspots in the scene, when hotspoty inits it adds to list
    public List<GameObject> hotSpots = new List<GameObject>();

    //int to indicate which audio from list to play
    int audioNumber;

    public enum ItemChoice
    {
        LIPSTICK,
        DRESS,
        SHOE
    }

    public ItemChoice itemChoice;

	void Start ()
    {
        //item equals dress whilst no choosing method implimented
        itemChoice = ItemChoice.DRESS;
        audioNumber = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ItemSelect();
    }

    //selects appropriate audio for item selected
    private void ItemSelect()
    {
        switch (itemChoice)
        {
            case ItemChoice.DRESS:
                if (selectedAudio != dressAudio)
                    selectedAudio = dressAudio;
                break;

            case ItemChoice.LIPSTICK:
                if (selectedAudio != lipstickAudio)
                    selectedAudio = lipstickAudio;
                break;

            case ItemChoice.SHOE:
                if (selectedAudio != shoeAudio)
                    selectedAudio = shoeAudio;
                break;
        }
    }

    public AudioClip GetSelectedAudio()
    {     
        return selectedAudio[audioNumber];
    }

    public void IncrementAudioNumber()
    {
        audioNumber++;
    }

    public void AddToHotSpotList(GameObject hotspot)
    {
        hotSpots.Add(hotspot);
    }
}
