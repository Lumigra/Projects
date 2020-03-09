using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public bool AllowFollowCamX;
    public bool AllowFollowCamY;
    public GameObject cam;

    private float xFollow;
    private float yFollow;

    private void Start()
    {
        AllowFollowCamX = true;
        AllowFollowCamY = true;

        if (AllowFollowCamX) xFollow = transform.position.x;
        if (AllowFollowCamY) yFollow = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null) cam = Camera.main.gameObject;

        cam.transform.position = new Vector3(xFollow, yFollow, cam.transform.position.z);

        if (AllowFollowCamX) xFollow = transform.position.x;
        if (AllowFollowCamY) yFollow = transform.position.y;
    }
}
