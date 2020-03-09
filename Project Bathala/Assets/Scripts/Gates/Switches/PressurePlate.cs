using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : Switch
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        activated.Invoke(true);
        sRenderer.sprite = ActiveState;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activated.Invoke(false);
        sRenderer.sprite = InactiveState;
    }
}
