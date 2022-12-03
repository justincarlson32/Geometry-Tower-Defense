using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMgr : MonoBehaviour
{

    public List<Enemy> enemies;

    public int round;

    public int totalKilled;

    public bool roundInProgress;

    public static WaveMgr inst;

    public float lastSpawnTime;

    public float spawnCooldown;

    public GameObject spawnNode;
    public Enemy baseEnemy;

    public int totalEnemies;

    public int spawnedEnemies;

    private void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    public void Start()
    {
        spawnNode = NodeMap.inst.nodeMap[0];
        spawnCooldown = 0.75f;
        lastSpawnTime = 0;
        round = 1;
        roundInProgress = false;
        spawnedEnemies = 0;
        totalEnemies = 4;
        totalKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (roundInProgress && !GameStateMgr.inst.isGamePaused)
        {
            if (totalEnemies == spawnedEnemies && (enemies.Count == 0))
            {
                endRound();
                return;
            }

            if (lastSpawnTime >= spawnCooldown && roundInProgress && (spawnedEnemies < totalEnemies))
            {
                spawnedEnemies++;
                spawnEnemy(1);
            }

            lastSpawnTime += Time.deltaTime;
        }
    }

    public void spawnEnemy(int strength)
    {
        Enemy newEnemy = (Enemy)Instantiate(baseEnemy, spawnNode.transform.localPosition, baseEnemy.transform.localRotation);
        newEnemy.position = spawnNode.transform.localPosition;
        newEnemy.unitLife = strength;
        newEnemy.tag = "enemy";
        enemies.Add(newEnemy);
        EnemyMgr.inst.enemySpawned();
        lastSpawnTime = 0;
    }

    public void startRound()
    {
        if (!roundInProgress)
        {
            totalEnemies = round * 4;
            spawnedEnemies = 0;
            roundInProgress = true;
        }
    }

    public void endRound()
    {
        roundInProgress = false;
        PlayerMgr.inst.playerMoney += round * 25;
        spawnCooldown -= 0.05f * round;
        if (spawnCooldown < 0.3f)
            spawnCooldown = .3f;
        round++;
        spawnedEnemies = 0;
        totalEnemies = round * 4;
    }

}
