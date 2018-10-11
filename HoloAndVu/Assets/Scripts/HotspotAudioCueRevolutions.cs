using UnityEngine;

public class HotspotAudioCueRevolutions : MonoBehaviour
{

    public AudioClip[] clips;
    public Transform objectToOrbit;

    private AudioSource audioSource;
    private float revolutionTime;
    private Vector3 rotationDirection;
    private bool isActive;

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
        isActive = !isActive;

        if (isActive)
        {
            int randomNum = Random.Range(0, clips.Length);
            audioSource.clip = clips[randomNum];

            revolutionTime = 360 / audioSource.clip.length;
            rotationDirection = new Vector3(Random.Range(0, 2), 1, Random.Range(0, 2));

            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    void Update()
    {
        if (isActive)
        {
            transform.RotateAround(objectToOrbit.transform.position,
            rotationDirection, revolutionTime * Time.deltaTime);
        }
    }
}