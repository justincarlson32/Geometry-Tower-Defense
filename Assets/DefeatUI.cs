using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefeatUI : MonoBehaviour
{
    public Text rounds, enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies.text = "Enemies Killed: " + WaveMgr.inst.totalKilled;
        rounds.text = "Rounds Survived: " + (WaveMgr.inst.round - 1);
    }


    public void quitButtonPressed()
    {
        Application.Quit();
    }

    public void playAgainButtonPressed()
    {
        WaveMgr.inst.Start();
        PlayerMgr.inst.Start();

        foreach(Enemy ene in WaveMgr.inst.enemies.ToArray())
        {

            foreach (Projectile proj in ene.projectiles.ToArray())
            {
                if (proj)
                    Destroy(proj.gameObject);
            }

            WaveMgr.inst.enemies.Remove(ene);
            Destroy(ene.gameObject);
        }

        foreach(PlaceableTile tile in Terrain.inst.tiles.ToArray())
        {
            if (!tile.isSpaceAvailable)
            {
                Destroy(tile.placedTower.gameObject);
                tile.isSpaceAvailable = true;
            }
        }

        UIMgr.inst.defeatUI.SetActive(false);
        GameStateMgr.inst.isGamePaused = false;
    }

}
