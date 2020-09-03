using UnityEngine;

public class CameraPosition : MonoBehaviour {
    public GameObject ObjToFollow;
    public float Offset;

	void Update () {
        if (ObjToFollow != null)
        {
            Vector3 newPos = transform.position;
            newPos.x = ObjToFollow.transform.position.x + Offset;
            transform.position = newPos;
        }
	}
}
