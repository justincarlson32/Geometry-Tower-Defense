using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyTower : Tower
{

    public Projectile proj;

    // Start is called before the first frame update
    void Start()
    {
        attackRadius = 100;
        attackSpeed = 1;
        upgradeSlot1 = 1;
        upgradeSlot2 = 1;
    }

    // Update is called once per frame
    void Update()
    {

        float floated1 = upgradeSlot1, floated2 = upgradeSlot2;

        attackSpeed = 1 + (0.20f * floated1);
        attackRadius = 10 + (0.20f * floated2);

        if (!GameStateMgr.inst.isGamePaused)
        {
            lastFiredTimeStamp += Time.deltaTime * attackSpeed;
            getClosestEnemy();
            if (tarEnemy && (tarEnemy.unitLife >= 1))
                if (lastFiredTimeStamp >= 1.5f)
                    shootProjectileAtEnemy(tarEnemy);
                else
                    tarEnemy = null;
        }
    }


    public void shootProjectileAtEnemy(Enemy ene)
    {
        Vector3 projPos = transform.localPosition;
        projPos.x -= 1.25f;
        Projectile newProj = Instantiate(proj,  projPos, transform.localRotation);

        newProj.inst = newProj;
        newProj.position = projPos;
        newProj.toEnt = ene;
        ene.projectiles.Add(newProj);
        lastFiredTimeStamp = 0;

        AudioSource audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

}
