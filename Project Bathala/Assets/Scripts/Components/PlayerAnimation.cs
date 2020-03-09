using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator PlayerAnimator;

    // Update is called once per frame
    void Update()
    {
        if (SingletonManager.Manager.GetSingleton<LevelManager>().GameState.IsPaused) return;
        if (!GetComponent<Player>().PlayerStatus.CanWalk) return;
 
        PlayerAnimator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        PlayerAnimator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        PlayerAnimator.SetFloat("Magnitude", GetMagnitude());        
    }

    private float GetMagnitude()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).magnitude;
    }
}
