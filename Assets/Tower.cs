using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int upgradeSlot1, upgradeSlot2;
    
    public float attackRadius;

    public float attackSpeed;

	public Enemy tarEnemy;

	public float lastFiredTimeStamp;


    // Start is called before the first frame update
    void Start()
    {
		attackSpeed = 1;
		lastFiredTimeStamp = 0;
		upgradeSlot1 = 1;
		upgradeSlot2 = 1;
	}

    // Update is called once per frame
    void Update()
    {

    }


    public void getClosestEnemy()
    {
		float shortestDistance = Mathf.Infinity;
		Enemy nearestEnemy = null;
		foreach (Enemy enemy in WaveMgr.inst.enemies)
		{
			if (enemy)
			{
				float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
				if (distanceToEnemy < shortestDistance)
				{
					shortestDistance = distanceToEnemy;
					nearestEnemy = enemy;
				}
			}
		}

		if (nearestEnemy != null && shortestDistance <= attackRadius)
		{
			tarEnemy = nearestEnemy;
		}
		else
		{
			tarEnemy = null;
		}
	}
}
