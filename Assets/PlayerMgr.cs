using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour
{

    public static PlayerMgr inst;

    public int playerLives;
    public int playerMoney;
    public bool playerDead;

    private void Awake()
    {
        inst = this;
    }

    public void Start()
    {
        playerLives = 10;
        playerMoney = 500;
        playerDead = false;
    }

    void Update()
    {
        if (playerLives == 0 && !playerDead)
        {
            playerDead = true;
            EnemyMgr.inst.playerDied();
            GameStateMgr.inst.isGamePaused = true;
            UIMgr.inst.defeatUI.SetActive(true);
        }
    }
}
