using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFollowCam : MonoBehaviour
{
    public bool DisableX;
    public bool DisableY;

    public FollowCam PlayerCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerCam == null) return;

        if (DisableX) PlayerCam.AllowFollowCamX = false;
        if (DisableY) PlayerCam.AllowFollowCamY = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (PlayerCam == null) return;

        if (DisableX) PlayerCam.AllowFollowCamX = true;
        if (DisableY) PlayerCam.AllowFollowCamY = true;
    }
}
