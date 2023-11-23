using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Lumin;

public class ThrobVFX : MonoBehaviour
{
    private Light lightComponent;

    [Range(0.1f, 5.0f)]
    public float ThrobIntensity;

    [Range(0.1f, 5.0f)]
    public float ThrobSpeed;

    [Range(1.0f, 5.0f)]
    public float Brightness;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        lightComponent.intensity = Mathf.Sin(Time.timeSinceLevelLoad * ThrobSpeed) * ThrobIntensity + Brightness;
    }
}
