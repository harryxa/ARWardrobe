using UnityEngine;

public class Hotspot : MonoBehaviour
{

    public delegate void HotspotEntered();
    public static event HotspotEntered OnEntered;

    public delegate void HotspotExited();
    public static event HotspotExited OnExited;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger Works");
        if (OnEntered != null && other.CompareTag("MainCamera"))
        {
            OnEntered();            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (OnExited != null && other.CompareTag("MainCamera"))
        {
            OnExited();
        }
    }
}