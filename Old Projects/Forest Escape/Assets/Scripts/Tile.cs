using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnTileDespawned : UnityEvent<Tile> { }

public class Tile : MonoBehaviour
{
    [HideInInspector] public OnTileDespawned OnTileDespawned = new OnTileDespawned();

    
    #region TileData
    public bool WillSpawnObstacles;
    public bool WillSpawnEnemies;
    public bool WillSpawnPickups;
    public float SpawnOffset;
    public float TimeToDestroyTile;
    public Transform BGSpawnPoint;
    public Transform ObjSpawnPoint;
    public GameObject TilePrefab;
    public Lanes Lanes;
    #endregion


    private int obsSpawnChance;
    private int enemySpawnChance;
    private int pickupSpawnChance;

    private Obstacle obstacle;
    private Enemy enemy;
    private Pickup pickup;

    private bool[] slotOccupied = new bool[3];

    private void Start()
    {
        for (int x = 0; x < slotOccupied.Length; x++) slotOccupied[x] = false;

        obsSpawnChance = GameScene.gameScene.SpawnerData.CurrentSet.ObstacleSpawnChance;
        enemySpawnChance = GameScene.gameScene.SpawnerData.CurrentSet.EnemySpawnChance;
        pickupSpawnChance = GameScene.gameScene.SpawnerData.CurrentSet.PickupSpawnChance;

        if (WillSpawnEnemies) SpawnEnemy();
        if (WillSpawnObstacles) SpawnObstacles();
        if (WillSpawnPickups) SpawnPickup();
    }


    void SpawnObstacles()
    {
        if (!rollForSpawn(obsSpawnChance)) return;

        int lanePosition = RollLane();
        int objType = RollObjType(ObstacleManager.Manager.ObjectTypes.Count);
        obstacle = ObstacleManager.Manager.GetObject(objType);

        if (obstacle == null)
        {
            obstacle = Instantiate(ObstacleManager.Manager.ObjectTypes[objType], Vector2.zero, Quaternion.identity);
            ObstacleManager.Manager.AddObject(obstacle);
        }
        obstacle.transform.position = new Vector2(ObjSpawnPoint.position.x, Lanes.GetLane(lanePosition).transform.position.y);
        obstacle.LaneNo = lanePosition;
        obstacle.ChangeOrder();
    }

    void SpawnEnemy()
    {
        if (!rollForSpawn(enemySpawnChance)) return;

        int lanePosition = RollLane();
        int objType = RollObjType(EnemyManager.Manager.ObjectTypes.Count);
        enemy = EnemyManager.Manager.GetObject(objType);

        if (enemy == null)
        {
            enemy = Instantiate(EnemyManager.Manager.ObjectTypes[objType], Vector2.zero, Quaternion.identity);
            EnemyManager.Manager.AddObject(enemy);
            enemy.enemyDestroyed.AddListener(EnemyManager.Manager.PoolObject);
        }

        enemy.transform.position = new Vector2(ObjSpawnPoint.position.x, Lanes.GetLane(lanePosition).transform.position.y);
        enemy.LaneNo = lanePosition;
        enemy.ChangeOrder();

        enemy.enemyDestroyed.AddListener(onEnemyDestroyed);
    }

    void SpawnPickup()
    {
        if (!rollForSpawn(pickupSpawnChance)) return;

        int lanePosition = RollLane();
        int objType = RollObjType(PickupManager.Manager.ObjectTypes.Count);
        pickup = PickupManager.Manager.GetObject(objType);

        if (pickup == null)
        {
            pickup = Instantiate(PickupManager.Manager.ObjectTypes[objType], Vector2.zero, Quaternion.identity);
            PickupManager.Manager.AddObject(pickup);

            pickup.pickedUp.AddListener(PickupManager.Manager.PoolObject);
        }

        pickup.transform.position = new Vector2(ObjSpawnPoint.position.x, Lanes.GetLane(lanePosition).transform.position.y);
        pickup.LaneNo = lanePosition;
        pickup.ChangeOrder();

        pickup.pickedUp.AddListener(onPickupCollected);
    }

    void SpawnTile()
    {
        Tile toSpawn = Instantiate(TilePrefab.GetComponent<Tile>(), BGSpawnPoint.position, Quaternion.identity);
    }

    int RollLane()
    {
        int laneNo = Random.Range(1, Lanes.GetLaneCount() + 1);
        while (slotOccupied[laneNo - 1]) laneNo = Random.Range(1, Lanes.GetLaneCount() + 1);
        slotOccupied[laneNo - 1] = true;
        return laneNo;
    }

    bool rollForSpawn(int spawnChance)
    {
        if (Random.Range(1, 101) < spawnChance) return true;
        return false;
    }

    int RollObjType(int count) { return Random.Range(0, count); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>()) {
            SpawnTile();
            StartCoroutine(DestroyTile());
        }
    }

    IEnumerator DestroyTile()
    {
        yield return new WaitForSeconds(TimeToDestroyTile);
        //OnTileDespawned.Invoke(this);
        if (obstacle != null && obstacle.gameObject.activeInHierarchy) ObstacleManager.Manager.PoolObject(obstacle);
        if (enemy != null && enemy.gameObject.activeInHierarchy) EnemyManager.Manager.PoolObject(enemy);
        if (pickup != null && pickup.gameObject.activeInHierarchy) PickupManager.Manager.PoolObject(pickup);
        Destroy(gameObject);
    }

    void onEnemyDestroyed(Enemy enemy)
    {
        this.enemy.enemyDestroyed.RemoveListener(onEnemyDestroyed);
        this.enemy = null;
    }

    void onPickupCollected(Pickup pickup)
    {
        this.pickup.pickedUp.RemoveListener(onPickupCollected);
        this.pickup = null;
    }
}
