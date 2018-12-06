using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Path Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float Speed;
    [SerializeField] float numEnemy;
    [SerializeField] float timeBetweenSpawn;

    public List<Transform> GetWaypoint()
    {
        var wayPoint = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            wayPoint.Add(child);
        }
        return wayPoint;
    }
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    public GameObject GetPath()
    {
        return pathPrefab;
    }
    public float GetSpeed()
    {
        return Speed;
    }
    public float GetNumberOfEnemy()
    {
        return numEnemy;
    }
    public float GetTimeBetweenSpawn()
    {
        return timeBetweenSpawn;
    }
}
