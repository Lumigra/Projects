using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnerData", menuName = "Spawner Data")]
public class GameData : ScriptableObject
{
    [SerializeField] private SpawnData[] DataSet;

    public SpawnData CurrentSet { get; private set; }

    public int GetSetCount() { return DataSet.Length; }
    public void GetNextSpawnData(int currentSet)
    {
        if (currentSet == DataSet.Length - 1) CurrentSet = DataSet[DataSet.Length-1];

        CurrentSet = DataSet[currentSet];
    }

    [System.Serializable]
    public struct SpawnData
    {
        public int ObstacleSpawnChance;
        public int EnemySpawnChance;
        public int PickupSpawnChance;

        public float PlayerSpeed;
        public float EnemySpeed;
    }
}
