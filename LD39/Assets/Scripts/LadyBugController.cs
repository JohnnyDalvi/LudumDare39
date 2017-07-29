using UnityEngine;

public class LadyBugController : EnemyController
{
    public Transform[] wayPoints;
    public float wayPointDistanceThreshold = 0.5f;
    int currentWaypoint;
    int nextWaypoint;
    void Start()
    {

    }

    void Update()
    {

    }

    protected override void MoveDirection(Vector3 target)
    {
        base.MoveDirection(target);
        Vector3 direction = target - transform.position;
        transform.position += direction.normalized * moveSpeed * Time.fixedDeltaTime;
    }

    protected override Vector3 WayPointChoser()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, wayPoints[currentWaypoint].position);
        if (distanceToWaypoint <= wayPointDistanceThreshold)
        {
            waypoint = NextWaypoint();
            return base.WayPointChoser();
        }
        waypoint = wayPoints[currentWaypoint].position;

        return base.WayPointChoser();

    }

    Vector3 NextWaypoint()
    {
        int maxWaypoints = wayPoints.Length;
        currentWaypoint++;
        if (currentWaypoint >= maxWaypoints)
            currentWaypoint = 0;
        return wayPoints[currentWaypoint].position;
    }
}