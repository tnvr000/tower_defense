using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
	private Transform target;
    private int wayPointIndex = 0;
	private Enemy enemy;
    void Start()
    {
		enemy = GetComponent<Enemy>();
        target = WayPoints.wayPoints[wayPointIndex];
    }
	void Update()
    {
        Vector3 direction = target.position - this.transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(this.transform.position, target.position) <= 0.30)
        {
            GetNextWayPoint();
        }
		enemy.speed = enemy.startSpeed;
    }
	void GetNextWayPoint()
    {
        if(wayPointIndex >= WayPoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }
        wayPointIndex++;
        target = WayPoints.wayPoints[wayPointIndex];
    }
    void EndPath() {
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
