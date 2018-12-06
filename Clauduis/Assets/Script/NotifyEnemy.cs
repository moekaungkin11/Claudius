using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyEnemy : EnemyPath
{
    [SerializeField] GameObject player;
    [SerializeField] float chaseDistance;

    EnemyPath enemyPath;
    HealthSystem healthSystem;
	// Use this for initialization
	void Start () {
        enemyPath = FindObjectOfType<EnemyPath>();
        healthSystem = FindObjectOfType<HealthSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position,player.transform.position)<=chaseDistance)
        {
            if (enemyPath)
            {
                Debug.Log("There is no enemypath");
            }
            if(healthSystem)
            {
                Debug.Log("Enemy doesn't has health system");
            }
             StopCoroutine(enemyPath.moveCoroutine);    
            //StartCoroutine(enemyPath.MoveTowardPlayer());
        }
	}
}
