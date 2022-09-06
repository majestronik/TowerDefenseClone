using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;
    private Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
        enemy = GetComponent<Enemy>();
    }

    void increaseSpeed()
    {
        enemy.speed = Mathf.Lerp(enemy.speed, enemy.startSpeed, .01f);
    }
    // Update is called once per frame
    void Update()
    {
        // Vector3 dir = target.position - transform.position;
        // transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.speed * Time.deltaTime);
        transform.LookAt(target.position);


        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        // Get back startspeed smoothly.
        if (enemy.speed >= enemy.startSpeed) return;
        increaseSpeed();

    }
    private void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
