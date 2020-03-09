using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LightPuzzle : Puzzle
{
    public List<LightTile> lightTiles = new List<LightTile>();
    public Transform ResetPoint;
    public float PathFlashTime;

    public Button Button;
    public bool ButtonCanReset;

    private List<LightTile> correctTiles = new List<LightTile>();
    private List<LightTile> incorrectTiles = new List<LightTile>();
    private Player player;
    private bool isActivated = false;

    void Start()
    {
        foreach (LightTile tile in lightTiles) tile.activated.AddListener(CheckTile);
        correctTiles = lightTiles.FindAll(s => s.IsCorrect);
        incorrectTiles = lightTiles.FindAll(s => !s.IsCorrect);
        Button.activated.AddListener(OnButtonPress);
    }

    void Update()
    {
        if (isSolved) return;
        if (correctTiles.All(s => s.IsSteppedOn))
        {
            completed.Invoke();
            isSolved = true;
            foreach(LightTile tile in incorrectTiles.ToArray())
            {
                tile.DeactivateTile();
            }
        }
    }

    public void OnButtonPress(bool Bool)
    {
        if(!isActivated)
        {
            isActivated = true;
            foreach(LightTile tile in lightTiles)
            {
                tile.ActivateTile();
            }
            FlashPath();
        }
    }

    public void FlashPath()
    {
        foreach (LightTile tile in lightTiles)
        {
            if (ButtonCanReset) tile.ResetTile();
            if (tile.IsCorrect) StartCoroutine(tile.FlashTile(PathFlashTime));
        }
    }

    void CheckTile(bool isCorrect)
    {
        if (isCorrect) return;
        ResetPuzzle();
    }

    void ResetPuzzle()
    {
        if (isSolved) return;
        Vector3 newPos = ResetPoint.position;
        newPos.z = player.transform.position.z;
        player.transform.position = newPos;
        if (!isActivated) return;
        foreach (LightTile tile in lightTiles.ToList()) tile.ResetTile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSolved) return;
        Player p_Player = collision.GetComponent<Player>();
        if (p_Player != null) player = p_Player;
    }
}
