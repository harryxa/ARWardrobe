using UnityEngine;

public class HotspotAudioCue : MonoBehaviour
{

    public AudioClip[] clips;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Hotspot.OnEntered += OnHotspotEnter;
    }

    private void OnDisable()
    {
        Hotspot.OnEntered -= OnHotspotEnter;
    }

    private void OnHotspotEnter()
    {
        int randomNum = Random.Range(0, clips.Length);
        audioSource.clip = clips[randomNum];
        audioSource.Play();
    }
}