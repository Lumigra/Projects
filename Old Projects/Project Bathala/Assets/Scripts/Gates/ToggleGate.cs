using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGate : MonoBehaviour
{
    public Switch Switch;
    public GameObject Gate;
    public bool ReverseSwitch;

    void Start()
    {
        Switch.activated.AddListener(Toggle);
    }

    void Toggle(bool switchState)
    {
        if (ReverseSwitch) Gate.SetActive(switchState);
        else Gate.SetActive(!switchState);
    }
}
