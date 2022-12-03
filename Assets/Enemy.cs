using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int unitLife;
    public List<Path> curPathQueue;
    public Path curPath;

    public Vector3 position;
    public float speed;
    public Vector3 velocity;

    public float heading;

    public Vector3 eulerRotation;

    public List<Projectile> projectiles;

    public Enemy(int life)
    {
        unitLife = life;
        handleNodePathCreation();
        curPath = curPathQueue[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 6;
        velocity = Vector3.zero;

        eulerRotation = new Vector3(90, 90, 0);

        handleNodePathCreation();
        curPath = curPathQueue[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStateMgr.inst.isGamePaused)
        {

            if (unitLife <= 0) // killed
            {
                WaveMgr.inst.enemies.Remove(this);
                EnemyMgr.inst.enemyDied();
                WaveMgr.inst.totalKilled++;
                Destroy(this.gameObject);
                foreach (Projectile proj in projectiles)
                {
                    if (proj)
                        Destroy(proj.gameObject);
                }
                return;
            }

            if (curPath.isComplete)
            {
                curPathQueue.RemoveAt(0);
                curPath = null;
            }

            if (curPathQueue.Count > 0)
            {
                curPath = curPathQueue[0];
                curPath.Tick();
            }

            if (curPathQueue.Count == 0) // made to base
            {
                PlayerMgr.inst.playerLives -= unitLife;
                EnemyMgr.inst.enemyReachedBase();
                WaveMgr.inst.enemies.Remove(this);
                Destroy(this.gameObject);
            }
        }
    }

    public void decrementLives()
    {
        PlayerMgr.inst.playerMoney += 10;
        unitLife--;
    }

    public void handleNodePathCreation()
    {
        for (int i = 1; i < 6; i++){
            Path addPath = new Path(this, NodeMap.inst.nodeMap[i].transform.localPosition);
            curPathQueue.Add(addPath);
        }
    }

}
