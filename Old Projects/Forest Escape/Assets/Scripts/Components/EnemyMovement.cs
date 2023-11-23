using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    private float speed;

    private void Start()
    {
        speed = GameScene.gameScene.SpawnerData.CurrentSet.EnemySpeed;
    }
    // Update is called once per frame
    void Update () {
        transform.position -= new Vector3(speed, 0) * Time.deltaTime; 
	}
}
