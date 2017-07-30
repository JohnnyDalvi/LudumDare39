using System.Collections;
using UnityEngine;

public class CaterpillarController : EnemyController
{
    public Transform[] wayPoints;
    public GameObject catBody;
    public GameObject catTail;
    public float bodyDistance;
    Transform lastBodyTarget;
    Vector3 finalDirection;
    public int catSize;
    public float wayPointDistanceThreshold = 0.5f;
    public float lerpTimer = 0.2f;
    float currentLerpTimer;
    bool isLerping;
    int currentWaypoint;
    int nextWaypoint;

    void Start()
    {
        lastBodyTarget = transform;
        CreateCat();
    }

    void CreateCat()
    {
        for (int catSIndex = 0; catSIndex < catSize; catSIndex++)
        {
            if (catSIndex >= catSize - 1)
            {
                InstantiateCatPiece(catTail);
            }
            else
            {
                InstantiateCatPiece(catBody);
            }
        }
    }

    void InstantiateCatPiece(GameObject prefab)
    {
        GameObject bodyPart = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        CaterpillarBody contrBody = bodyPart.GetComponent<CaterpillarBody>();
        contrBody.target = lastBodyTarget;
        contrBody.maximumDistance = bodyDistance;
        lastBodyTarget = bodyPart.transform;
        contrBody.headReference = this;
    }


    void Update()
    {
        if (isLerping)
        {
            currentLerpTimer += Time.deltaTime;
        }
    }

    protected override void MoveDirection(Vector3 target)
    {
        base.MoveDirection(target);
        float distanceToWaypoint = Vector3.Distance(transform.position, wayPoints[currentWaypoint].position);



        Vector3 direction = target - transform.position;
        Vector3 direction2 = NextWaypoint(false) - transform.position;

        if (isLerping || distanceToWaypoint <= wayPointDistanceThreshold)
        {
            finalDirection = Vector3.Lerp(direction, direction2, currentLerpTimer / lerpTimer);
            if (isLerping == false)
                StartCoroutine(ChangeWaypoint());
        }
        else
        {
            finalDirection = direction;
        }
        transform.position += finalDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        lookAtDirection(finalDirection + transform.position);

    }

    protected override Vector3 WayPointChoser()
    {
        waypoint = wayPoints[currentWaypoint].position;
        return base.WayPointChoser();

    }

    IEnumerator ChangeWaypoint()
    {
        isLerping = true;
        yield return new WaitForSeconds(lerpTimer);
        isLerping = false;
        currentLerpTimer = 0;
        waypoint = NextWaypoint(true);
    }

    Vector3 NextWaypoint(bool change)
    {
        int next = currentWaypoint;
        int maxWaypoints = wayPoints.Length;

        if (change)
        {
            currentWaypoint++;
            if (currentWaypoint >= maxWaypoints)
                currentWaypoint = 0;
            return wayPoints[currentWaypoint].position;

        }
        else
        {
            next++;
            if (next >= maxWaypoints)
                next = 0;
            return wayPoints[next].position;

        }

    }
}
