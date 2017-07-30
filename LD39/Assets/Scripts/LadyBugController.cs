using System.Collections;
using UnityEngine;


public class LadyBugController : EnemyController
{
    public Transform[] wayPoints;
    public float wayPointDistanceThreshold = 0.5f;
    int currentWaypoint;
    int nextWaypoint;
    public float slowDownTimer;
    float currentSlowDownTimer;
    bool isSlowwingDown;

    void Update()
    {
        if (isSlowwingDown)
            currentSlowDownTimer += Time.deltaTime;
    }

    protected override void MoveDirection(Vector3 target)
    {
        base.MoveDirection(target);
        Vector3 direction = target - transform.position;
        if (isSlowwingDown)
        {
            float slowPercentage = Mathf.Abs(currentSlowDownTimer - slowDownTimer / 2) / (slowDownTimer / 2);
            transform.position += direction.normalized * moveSpeed * Time.fixedDeltaTime * slowPercentage;
        }
        else
            transform.position += direction.normalized * moveSpeed * Time.fixedDeltaTime;
        lookAtDirection(target);
    }

    protected override Vector3 WayPointChoser()
    {
        float distanceToWaypoint = Vector3.Distance(transform.position, wayPoints[currentWaypoint].position);
        if (distanceToWaypoint <= wayPointDistanceThreshold)
        {
            if (!isSlowwingDown)
                StartCoroutine(TurnArround());
        }
        waypoint = wayPoints[currentWaypoint].position;

        return base.WayPointChoser();


    }

    IEnumerator TurnArround()
    {
        isSlowwingDown = true;
        yield return new WaitForSeconds(slowDownTimer / 2);
        waypoint = NextWaypoint();
        yield return new WaitForSeconds(slowDownTimer / 2);
        currentSlowDownTimer = 0;
        isSlowwingDown = false;
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