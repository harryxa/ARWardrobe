using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelecter : MonoBehaviour
{
    private GameObject GameObjAudioManager;
    private AudioManager m_AudioManager;

    // Use this for initialization
    void Start()
    {
        GameObjAudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        m_AudioManager = GameObjAudioManager.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_AudioManager.itemChoice == AudioManager.ItemChoice.NONE)
        {            
            if (gameObject.tag == "Becs")
            {
                m_AudioManager.itemChoice = AudioManager.ItemChoice.BECS;
            }
            else if (gameObject.tag == "Micah")
            {
                m_AudioManager.itemChoice = AudioManager.ItemChoice.MICAH;
            }
            else if (gameObject.tag == "Jamie")
            {
                m_AudioManager.itemChoice = AudioManager.ItemChoice.JAMIE;
            }
        }
    }
}
