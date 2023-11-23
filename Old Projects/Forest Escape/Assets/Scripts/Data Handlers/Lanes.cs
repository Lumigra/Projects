using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Lanes")]
public class Lanes : ScriptableObject {

    [SerializeField]
    private List<GameObject> lanes = new List<GameObject>();

    public GameObject GetLane(int laneNo)
    {
        if (laneNo < 0) return lanes[0];
        if (laneNo > lanes.Count) return lanes[lanes.Count];
        return lanes[laneNo - 1];
    }
    public int GetLaneCount()
    {
        return lanes.Count;
    }
}
