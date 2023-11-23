using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : Pickup {
    public int Score;

    protected override void TriggerEffect(Collider2D collider)
    {
        GameScene.gameScene.IncreaseScore(Score);
        pickedUp.Invoke(this);
    }
}
