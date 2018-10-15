using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool isDress = false;
    public bool isLipstick = false;
    public bool isShoe = false;
         
    // Use this for initialization
	void Start ()
    {
        isDress = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isDress == true)
        {
            isLipstick = false;
            isShoe = false;
        }
        else if (isLipstick == true)
        {
            isDress = false;
            isShoe = false;
        }
        else if (isShoe == true)
        {
            isDress = false;
            isLipstick = false;
        }
    }
}
