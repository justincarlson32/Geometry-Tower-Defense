using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTower : Tower
{

    // Start is called before the first frame update
    void Start()
    {
        attackRadius = 8;
        attackSpeed = 0.25f;
        upgradeSlot1 = 1;
        upgradeSlot2 = 1;
    }

    // Update is called once per frame
    void Update()
    {

        float floated1 = upgradeSlot1, floated2 = upgradeSlot2;

        attackSpeed = 0.25f + (0.05f * floated1);
        attackRadius = 8 + (0.20f * floated2);

        if (!GameStateMgr.inst.isGamePaused)
        {
            lastFiredTimeStamp += Time.deltaTime * attackSpeed;
            if (lastFiredTimeStamp >= 1.5f)
                shootRadialAttack();

        }
    }


    public void shootRadialAttack()
    {
        foreach (Enemy enemy in WaveMgr.inst.enemies)
        {
            if (enemy)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < attackRadius)
                {
                    enemy.decrementLives();
                }
            }
        }
        lastFiredTimeStamp = 0;
    }

}
