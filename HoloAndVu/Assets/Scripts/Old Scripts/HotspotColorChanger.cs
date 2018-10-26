using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class HotspotColorChanger : MonoBehaviour
{
    public Color activeColor = Color.red;

    private Color originalColor;
    private Material cachedMaterial;

    private void Awake()
    {
        cachedMaterial = GetComponent<Renderer>().material;
        originalColor = cachedMaterial.GetColor("_Color");
    }

    private void OnEnable()
    {
        Hotspot.OnEntered += OnHotspotEnter;
        Hotspot.OnExited += OnHotspotExit;
    }

    private void OnDisable()
    {
        Hotspot.OnEntered -= OnHotspotEnter;
        Hotspot.OnExited -= OnHotspotExit;
    }

    private void OnHotspotEnter()
    {
        cachedMaterial.SetColor("_Color", activeColor);
    }

    private void OnHotspotExit()
    {
        cachedMaterial.SetColor("_Color", originalColor);
    }

    private void OnDestroy()
    {
        DestroyImmediate(cachedMaterial);
    }
}