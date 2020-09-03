using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public void SetText(double score)
    {
        textMesh.text = "You got " + score.ToString() + "points";
    }
}
