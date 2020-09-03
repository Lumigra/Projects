using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI_Score : MonoBehaviour {

    public GameScene scene;
    public TextMeshProUGUI TextMesh;

    private void Start()
    {
        GameScene scene = this.scene.GetComponent<GameScene>();
        scene.scoreChange.AddListener(ChangeScore);
        TextMesh.text = "0";
    }

    void ChangeScore(double score)
    {
        TextMesh.text = score.ToString("0.0");
    }
}
