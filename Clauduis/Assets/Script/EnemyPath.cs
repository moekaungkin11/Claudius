using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] float timeBetweenWaypointing;
    [SerializeField] GameObject player;
    [SerializeField] float chaseDistance;
    [SerializeField] WaveConfig waveConfig;
    
    Rigidbody2D myRigidbody;
    public Coroutine moveCoroutine;
   // WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        waypoints = waveConfig.GetWaypoint();
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    void Update()
    {
        //moveCoroutine = StartCoroutine(MoveWaypoint());
    }
    public IEnumerator MoveTowardPlayer()
    {
        myRigidbody.velocity = new Vector2(player.transform.position.x, 0);
        yield return new WaitForSeconds(2f);
    }
    public IEnumerator MoveWaypoint()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            transform.position = Vector2.MoveTowards(
                transform.position,
                targetPosition,
                waveConfig.GetSpeed());
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            waypointIndex = 0;
        }
        //else
        //{
        //    var targetPosition = waypoints[waypointIndex].transform.position;
        //    transform.position = Vector2.MoveTowards(
        //    transform.position,
        //    targetPosition,
        //    waveConfig.GetSpeed());
        //    if (transform.position == targetPosition)
        //    {
        //        waypointIndex--;
        //    }
        //}
        yield return new WaitForSeconds(timeBetweenWaypointing);
    }
}
