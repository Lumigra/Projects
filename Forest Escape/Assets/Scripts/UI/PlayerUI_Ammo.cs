using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerUI_Ammo : MonoBehaviour {

    public PlayerShoot Player;
    public TextMeshProUGUI textMesh;

	void Start () {
        Player.AmmoChanged.AddListener(ChangeText);
        textMesh.text = "Ammo: " + Player.GetAmmo().ToString();
	}
	
	void ChangeText(int ammo)
    {
        textMesh.text = "Ammo: " + ammo.ToString();
    }
}
