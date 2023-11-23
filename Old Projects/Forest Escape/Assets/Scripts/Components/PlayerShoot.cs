using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAmmoChange : UnityEvent<int> { }
public class PlayerShoot : MonoBehaviour
{
    [HideInInspector] public OnAmmoChange AmmoChanged = new OnAmmoChange();

    public KeyCode FireKey;
    public Transform ArrowSpawn;
    public GameObject ArrowPrefab;
    public int MaxAmmo = 5;
    [SerializeField] private int ammo;

	// Use this for initialization
	void Start () {
        if (MaxAmmo <= 0)
            MaxAmmo = 5;
        ammo = MaxAmmo;
	}

    private void Update()
    {
        if (Input.GetKeyDown(FireKey)) Fire();
    }

    public void Fire()
    {
        if (ammo <= 0)
            return;

        Arrow arrow = ArrowManager.Manager.GetObject(0);
        if (arrow == null)
        {
            arrow = Instantiate(ArrowManager.Manager.ObjectTypes[0]);
            ArrowManager.Manager.AddObject(arrow);
        }

        arrow.transform.position = ArrowSpawn.position;
        arrow.SetSpeed(GetComponent<PlayerMovement>().speed);
        arrow.LaneNo = GetComponent<ILaning>().GetLane();
        arrow.ChangeOrder();
        arrow.Expired.AddListener(ArrowManager.Manager.PoolObject);

        ammo--;
        AmmoChanged.Invoke(ammo);
    }

    public void AddAmmo(int ammoCount)
    {
        ammo += ammoCount;
        if (ammo > MaxAmmo) ammo = MaxAmmo;
        AmmoChanged.Invoke(ammo);
    }

    public int GetAmmo()
    {
        return ammo;
    }
}
